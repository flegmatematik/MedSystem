using System.Collections.Generic;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Uzivatel;

namespace APIMedSystem.Services.UzivateliaService
{
    public interface IUzivateliaService
    {
        Task<ServiceResponse<List<GetUzivatelDto>>> GetAllUzivatelia();
        Task<ServiceResponse<GetUzivatelDto>> GetUzivatelById(int id);
        Task<ServiceResponse<List<GetUzivatelDto>>> AddUzivatel(AddUzivatelDto novyUzivatel);
        Task<ServiceResponse<GetUzivatelDto>> UpdateUzivatel(UpdateUzivatelDto updatedUzivatel);
        Task<ServiceResponse<List<GetUzivatelDto>>> DeleteUzivatel(int id);
    }
}
