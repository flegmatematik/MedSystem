using System.Collections.Generic;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Osoba;

namespace APIMedSystem.Services.OsobyService
{
    public interface IOsobyService
    {
        Task<ServiceResponse<List<GetOsobaDto>>> GetAllOsoby();
        Task<ServiceResponse<GetOsobaDto>> GetOsobaById(int id);
        Task<ServiceResponse<List<GetOsobaDto>>> AddOsoba(AddOsobaDto novaOsoba);
        Task<ServiceResponse<GetOsobaDto>> UpdateOsoba(UpdateOsobaDto updatedOsoba);
        Task<ServiceResponse<List<GetOsobaDto>>> DeleteOsoba(int id);
    }
}
