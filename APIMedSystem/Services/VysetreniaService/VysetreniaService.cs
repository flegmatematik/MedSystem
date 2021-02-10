using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Vysetrenie;
using AutoMapper;
using MedSystem.Database;
using MedSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMedSystem.Services.VysetreniaService
{
    /// <summary>
    /// Service ktorý ponúka manipuláciu s vyšetreniami, ako aj objednávanie alebo získanie najbližších vyšetrení
    /// </summary>
    public class VysetreniaService : IVysetreniaService
    {
        private readonly IMapper _mapper;

        private readonly MedSystemDatabaseContext _context;

        public VysetreniaService(MedSystemDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Vráti údaje o vyšetrení podľa zadaného id
        /// </summary>
        /// <param name="vysetrenieId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetVysetrenieDto>> GetVysetrenieById(int vysetrenieId)
        {
            ServiceResponse<GetVysetrenieDto> serviceResponse = new ServiceResponse<GetVysetrenieDto>();
            serviceResponse.Data = _mapper.Map<GetVysetrenieDto>( await _context.Vysetrenia.FindAsync(vysetrenieId));
            if (serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Dané vyšetrenie nebolo nájdené.";
            }
            else
            {
                serviceResponse.Success = true;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Vráti všetky vyšetrenia v databáze
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetAllVysetrenia()
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            serviceResponse.Data =
                await _context.Vysetrenia.Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();
            return serviceResponse;
        }

        /// <summary>
        /// Vráti všetky vyšetrenia jednej osoby podľa jej id
        /// </summary>
        /// <param name="osobaId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetVysetreniaByOsobaId(int osobaId)
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            serviceResponse.Data = await _context.Vysetrenia.Where(c => c.Pacient.OsobaId == osobaId)
                .Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();
            return serviceResponse;
        }

        /// <summary>
        /// Vráti všetky vyšetrenia jednej osoby podľa id a do istého časového okamihu
        /// </summary>
        /// <param name="osobaId"></param>
        /// <param name="lastDateTime"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetVysetreniaByOsobaIdByDateTime(int osobaId,
            DateTime lastDateTime)
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            serviceResponse.Data = await _context.Vysetrenia
                .Where(c => c.Pacient.OsobaId == osobaId &&
                            (c.ObjednanyTermin <= lastDateTime && c.ObjednanyTermin >= DateTime.Now))
                .Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();
            return serviceResponse;
        }


        /// <summary>
        /// Pridá nové vyšetrenie do databázy na základe údajov. AutoMapper nevyužitý z dôvodu konštrukcie dát,
        /// a využité manuálne mapovanie pomocou lazy loadingu z proxy
        /// </summary>
        /// <param name="noveVysetrenie"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetVysetrenieDto>> AddVysetrenie(AddVysetrenieDto noveVysetrenie)
        {
            ServiceResponse<GetVysetrenieDto> serviceResponse = new ServiceResponse<GetVysetrenieDto>();

            Vysetrenie vysetrenie = _context.CreateProxy<Vysetrenie>();
            vysetrenie.PacientId = noveVysetrenie.PacientId;
            vysetrenie.ZPersonalId = noveVysetrenie.ZPersonalId;
            vysetrenie.TypVysetreniaId = noveVysetrenie.TypVysetreniaId;
            vysetrenie.Ambulancia = noveVysetrenie.Ambulancia;

            try
            {
                await _context.Vysetrenia.AddAsync(vysetrenie);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVysetrenieDto>(vysetrenie);
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Vráti všetky už objednané vyšetrenia jednej osoby podľa id
        /// </summary>
        /// <param name="osobaId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetUnapprovedVysetrenia(int osobaId)
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            try
            {
                serviceResponse.Data = await _context.Vysetrenia
                    .Where(c => c.Pacient.OsobaId == osobaId &&
                                c.ObjednanyTermin == DateTime.MinValue)
                    .Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();

                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        /// <summary>
        /// Podľa zadaného id vyšetrenia a dátumu dňa vyberie všetky časy, na ktoré sa pacient môže objednať,
        /// závisí od harmonogramu doktora ako aj pacienta
        /// </summary>
        /// <param name="idVysetrenia"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<string>>> GetAppointmentTimes(int idVysetrenia, DateTime date)
        {
            ServiceResponse<List<string>> serviceResponse = new ServiceResponse<List<string>>();

            var vysetrenie = (await _context.Vysetrenia.FindAsync(idVysetrenia));

            int personalId =  vysetrenie.ZPersonalId;
            int pacientId = vysetrenie.PacientId;

            List<string> availableTimes = new List<string>() 
            {
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
            };
            try
            {
                List<string> timeListPersonal = await _context.Vysetrenia
                    .Where(c => c.ZPersonalId == personalId && c.ObjednanyTermin.Date == date)
                    .Select(c => c.ObjednanyTermin.ToString("HH:mm")).ToListAsync();

                List<string> timeListPacient = await _context.Vysetrenia
                    .Where(c => c.PacientId == pacientId && c.ObjednanyTermin.Date == date)
                    .Select(c => c.ObjednanyTermin.ToString("HH:mm")).ToListAsync();

                serviceResponse.Data = availableTimes.Where(c => timeListPersonal.All(p2 => p2 != c) && timeListPacient.All(p3 => p3 != c)).ToList();
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Objednanie vyšetrenia na zadaný čas podľa id vyšetrenia
        /// </summary>
        /// <param name="objednanyCas"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetVysetrenieDto>> SetAppointmentTime(SetTimeVysetrenieDto objednanyCas)
        {
            ServiceResponse<GetVysetrenieDto> serviceResponse = new ServiceResponse<GetVysetrenieDto>();

            try
            {
                Vysetrenie vysetrenie = await _context.Vysetrenia.FindAsync(objednanyCas.VysetrenieId);
                vysetrenie.ObjednanyTermin = objednanyCas.DateTime;
                vysetrenie.ObjednanePacientom = true;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetVysetrenieDto>(vysetrenie);
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Získanie všetkých vyšetrení osoby ktoré sa stali v minulosti
        /// </summary>
        /// <param name="osobaId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetHistory(int osobaId)
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            try
            {
                serviceResponse.Data = await _context.Vysetrenia
                    .Where(c => c.Pacient.OsobaId == osobaId &&
                                c.ObjednanyTermin <= DateTime.Now && c.ObjednanyTermin > DateTime.MinValue)
                    .Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();

                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVysetrenieDto>>> GetOckovaniaHistory(int osobaId)
        {
            ServiceResponse<List<GetVysetrenieDto>> serviceResponse = new ServiceResponse<List<GetVysetrenieDto>>();
            try
            {
                serviceResponse.Data = await _context.Vysetrenia
                    .Where(c => c.Pacient.OsobaId == osobaId
                                && c.ObjednanyTermin <= DateTime.Now 
                                && c.ObjednanyTermin > DateTime.MinValue
                                && c.TypVysetrenia.Nazov.ToLower().Contains("covid-19") 
                                && (c.TypVysetrenia.Nazov.ToLower().Contains("očkovanie")
                                    || c.TypVysetrenia.Nazov.ToLower().Contains("vakcína")))
                    .Select(c => _mapper.Map<GetVysetrenieDto>(c)).ToListAsync();

                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
