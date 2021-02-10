using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Uzivatel;
using AutoMapper;
using MedSystem.Database;
using MedSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMedSystem.Services.UzivateliaService
{
    /// <summary>
    /// Service, ktorý ponúka metódy na manipuláciu s Užívateľmi v databáze
    /// </summary>
    public class UzivateliaService :IUzivateliaService
    {
        private readonly IMapper _mapper;

        private readonly MedSystemDatabaseContext _context;

        public UzivateliaService(MedSystemDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Vráti údaje o všetkých užívateľoch
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetUzivatelDto>>> GetAllUzivatelia()
        {
            ServiceResponse<List<GetUzivatelDto>> serviceResponse = new ServiceResponse<List<GetUzivatelDto>>();
            serviceResponse.Data = await _context.Uzivatelia.Select(c => _mapper.Map<GetUzivatelDto>(c)).ToListAsync();
            return serviceResponse;
        }

        /// <summary>
        /// Vráti údaje o jednom užívateľovi podľa zadaného id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetUzivatelDto>> GetUzivatelById(int id)
        {
            ServiceResponse<GetUzivatelDto> serviceResponse = new ServiceResponse<GetUzivatelDto>();
            serviceResponse.Data = _mapper.Map<GetUzivatelDto>(await _context.Uzivatelia.FirstOrDefaultAsync(c => c.Id == id));
            return serviceResponse;
        }

        /// <summary>
        /// Pridá užívateľa podľa zadaných údajov
        /// </summary>
        /// <param name="novyUzivatel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetUzivatelDto>>> AddUzivatel(AddUzivatelDto novyUzivatel)
        {
            ServiceResponse<List<GetUzivatelDto>> serviceResponse = new ServiceResponse<List<GetUzivatelDto>>();
            try
            {
                Uzivatel uzivatel = _mapper.Map<Uzivatel>(novyUzivatel);
                await _context.Uzivatelia.AddAsync(uzivatel);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Uzivatelia.Select(c => _mapper.Map<GetUzivatelDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        /// <summary>
        /// Upraí všetky hodnoty Užívateľa podľa zadaného id
        /// </summary>
        /// <param name="updatedUzivatel"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetUzivatelDto>> UpdateUzivatel(UpdateUzivatelDto updatedUzivatel)
        {
            ServiceResponse<GetUzivatelDto> serviceResponse = new ServiceResponse<GetUzivatelDto>();
            try
            {
                Uzivatel uzivatel = await _context.Uzivatelia.FirstOrDefaultAsync(c => c.Id == updatedUzivatel.Id);
                if (updatedUzivatel.Email != null)
                {
                    uzivatel.Email = updatedUzivatel.Email;
                }

                if (updatedUzivatel.TelefonneCislo != null)
                {
                    uzivatel.TelefonneCislo = updatedUzivatel.TelefonneCislo;
                }

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUzivatelDto>(uzivatel);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        /// <summary>
        /// Odstráni užívateľa podľa zadaného id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetUzivatelDto>>> DeleteUzivatel(int id)
        {
            ServiceResponse<List<GetUzivatelDto>> serviceResponse = new ServiceResponse<List<GetUzivatelDto>>();
            try
            {
                Uzivatel uzivatel = await _context.Uzivatelia.FirstAsync(c => c.Id == id);
                _context.Uzivatelia.Remove(uzivatel);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Uzivatelia.Select(c => _mapper.Map<GetUzivatelDto>(c)).ToList();
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
