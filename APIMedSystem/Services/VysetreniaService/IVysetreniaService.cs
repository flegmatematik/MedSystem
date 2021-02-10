using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Vysetrenie;

namespace APIMedSystem.Services.VysetreniaService
{
    public interface IVysetreniaService
    {
        Task<ServiceResponse<GetVysetrenieDto>> GetVysetrenieById(int vysetrenieId);

        Task<ServiceResponse<List<GetVysetrenieDto>>> GetAllVysetrenia();
        Task<ServiceResponse<List<GetVysetrenieDto>>> GetVysetreniaByOsobaId(int osobaId);
        Task<ServiceResponse<List<GetVysetrenieDto>>> GetVysetreniaByOsobaIdByDateTime(int osobaId, DateTime lastDateTime);

        Task<ServiceResponse<GetVysetrenieDto>> AddVysetrenie(AddVysetrenieDto noveVysetrenie);

        Task<ServiceResponse<List<GetVysetrenieDto>>> GetUnapprovedVysetrenia(int osobaId);
        Task<ServiceResponse<List<string>>> GetAppointmentTimes(int idVysetrenia, DateTime date);
        Task<ServiceResponse<GetVysetrenieDto>> SetAppointmentTime(SetTimeVysetrenieDto objednanyCas);
        Task<ServiceResponse<List<GetVysetrenieDto>>> GetHistory(int osobaId);
        Task<ServiceResponse<List<GetVysetrenieDto>>> GetOckovaniaHistory(int osobaId);
    }
}
