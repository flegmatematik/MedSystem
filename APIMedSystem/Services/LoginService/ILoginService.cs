using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Login;
using APIMedSystem.DTOS.Osoba;
using APIMedSystem.DTOS.Uzivatel;

namespace APIMedSystem.Services.LoginService
{
    public interface ILoginService
    {
        Task<ServiceResponse<GetUzivatelDto>> RegisterUser(RegisterDto novyUzivatel);
        Task<ServiceResponse<GetOsobaDto>> LoginUser(LoginDto prihlasovacieUdaje);
    }
}
