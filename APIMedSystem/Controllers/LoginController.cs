using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using APIMedSystem.DTOS.Login;
using APIMedSystem.Services.LoginService;


namespace APIMedSystem.Controllers
{
    /// <summary>
    /// Api Controller, ktory prijímna requesty na danych endpointoch
    /// Každá operácia má v popise aj svoj príklad použita.
    /// Zatiaľ neobsahuje autentifikáciu ani autorizáciu
    /// </summary>
     

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        // obsahuje všetky metódy login servicu
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST: Login/SignIn
        [HttpPost("SignIn")]
        public async Task<ActionResult> LoginUser(LoginDto novyUzivatel)
        {
            return Ok(await _loginService.LoginUser(novyUzivatel));
        }


        // POST: Login/Register
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(RegisterDto novyUzivatel)
        {
            return Ok(await _loginService.RegisterUser(novyUzivatel));
        }
    }
}
