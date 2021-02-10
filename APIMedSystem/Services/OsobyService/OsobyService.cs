using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Osoba;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MedSystem.Database;
using MedSystem.Database.Models;

namespace APIMedSystem.Services.OsobyService
{
    /// <summary>
    /// Service, ktorý ponúka metódy na manipuláciu s Osobami v databáze
    /// </summary>
    public class OsobyService : IOsobyService
    {
        // automapper sa využíva na premenu záznamov z dátového modelu na dáta, ktoré chcem vrátiť naspäť užívateľovi
        private readonly IMapper _mapper;

        // context databázy
        private readonly MedSystemDatabaseContext _context;

        public OsobyService(MedSystemDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Vráti určité dáta o všetkých Osobách v databáze
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetOsobaDto>>> GetAllOsoby()
        {
            ServiceResponse<List<GetOsobaDto>> serviceResponse = new ServiceResponse<List<GetOsobaDto>>();
            serviceResponse.Data = await _context.Osoby.Select(c => _mapper.Map<GetOsobaDto>(c)).ToListAsync();
            return serviceResponse;
        }

        /// <summary>
        /// Vráti údaje o konkrétnej osobe definovanej id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetOsobaDto>> GetOsobaById(int id)
        {
            ServiceResponse<GetOsobaDto> serviceResponse = new ServiceResponse<GetOsobaDto>();
            serviceResponse.Data = _mapper.Map<GetOsobaDto>(await _context.Osoby.FirstOrDefaultAsync(c => c.Id == id));
            return serviceResponse;
        }

        /// <summary>
        /// Pridá osobu na základe poskynutých dát
        /// </summary>
        /// <param name="novaOsoba"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetOsobaDto>>> AddOsoba(AddOsobaDto novaOsoba)
        {
            ServiceResponse<List<GetOsobaDto>> serviceResponse = new ServiceResponse<List<GetOsobaDto>>();
            Osoba osoba = _mapper.Map<Osoba>(novaOsoba);
            await _context.Osoby.AddAsync(osoba);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Osoby.Select(c => _mapper.Map<GetOsobaDto>(c))).ToList();
            return serviceResponse;
        }

        /// <summary>
        /// Upraví všetky atribúty Osoby v databáze na základe poskytnutého ID
        /// </summary>
        /// <param name="updatedOsoba"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetOsobaDto>> UpdateOsoba(UpdateOsobaDto updatedOsoba)
        {
            ServiceResponse<GetOsobaDto> serviceResponse = new ServiceResponse<GetOsobaDto>();
            try
            {
                Osoba osoba = await _context.Osoby.FirstOrDefaultAsync(c => c.Id == updatedOsoba.Id);
                osoba.Adresa = updatedOsoba.Adresa;
                osoba.CeleMeno = updatedOsoba.CeleMeno;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetOsobaDto>(osoba);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Odstráni osobu z databázy na základe daného id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetOsobaDto>>> DeleteOsoba(int id)
        {
            ServiceResponse<List<GetOsobaDto>> serviceResponse = new ServiceResponse<List<GetOsobaDto>>();
            try
            {
                Osoba osoba = await _context.Osoby.FirstAsync(c => c.Id == id);
                _context.Osoby.Remove(osoba);

                serviceResponse.Data = _context.Osoby.Select(c => _mapper.Map<GetOsobaDto>(c)).ToList();

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
