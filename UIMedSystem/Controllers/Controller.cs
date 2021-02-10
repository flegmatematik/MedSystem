using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UIMedSystem.DataTypes;

namespace UIMedSystem.Controllers
{
    /// <summary>
    /// Controller na všetky operácie UI na komunikáciu s API. Na komunikáciu využíva HttpClient.
    /// Využíva návrhvý vzor Singleton
    /// </summary>
    public class Controller
    {
        private static Controller _instance;
        private static readonly HttpClient WebApi = new HttpClient();
        private bool _loggedIn;
        private DateTime _logoutTime;

        // Obsahuje informácie o používateľovi
        public UserProfile User { get; set; }

        public static Controller Instance => _instance ?? (_instance = new Controller());


        /// <summary>
        /// Vracia true ak je užívateľ už prihlásený, prípadne ho dohlási ak už prekročil hranicu platnosti
        /// jeho prihlásenia
        /// </summary>
        /// <returns></returns>
        public bool LoggedIn()
        {
            _loggedIn = DateTime.Now < _logoutTime && _loggedIn;
            return _loggedIn;
        }

        /// <summary>
        /// Odhlásenie užívateľa
        /// </summary>
        public void Logout()
        {
            _loggedIn = false;
            User = null;
        }

        /// <summary>
        /// Prihlásenie užívateľa na základe údajov, a nastavenie 10 minútového časovača platnosti.
        /// Vracia informácie o užívateľovi
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Login(string email, string password)
        {

            var values = new
            {
                Email = email,
                Heslo = password
            };

            var response = await WebApi.PostAsJsonAsync("https://localhost:5001/Login/SignIn", values);

            if (response.IsSuccessStatusCode)
            {
                _logoutTime = DateTime.Now.AddMinutes(10);

                var responseString = await response.Content.ReadAsStringAsync();
                var details = JObject.Parse(responseString);

                bool success = details["success"]?.ToObject<bool>() ?? false;

                if (success)
                {
                    User = details["data"]?.ToObject<UserProfile>();
                    _loggedIn = true;
                    _logoutTime = DateTime.Now.AddMinutes(10);
                }
            }

            return response;
        }

        /// <summary>
        /// Registrácia užívateľa na základe daných údajov
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rodneCislo"></param>
        /// <param name="celeMeno"></param>
        /// <param name="adresa"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Register(string email, string password, long rodneCislo, string celeMeno, string adresa)
        {
            var values = new
            {
                RodneCislo = rodneCislo,
                CeleMeno = celeMeno,
                Adresa = adresa,
                Email = email,
                Heslo = password
            };

            var response = await WebApi.PostAsJsonAsync("https://localhost:5001/Login/Register", values);

            return response;
        }

        /// <summary>
        /// Získanie vyšetrení pacienta v nasledujúcom týždni
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetVysetreniaNextWeek()
        {
            string uri = $"https://localhost:5001/Vysetrenia/{User.Id}/{DateTime.Now.AddDays(7):yyyyMMddHHmmss}";

            var response = await WebApi.GetAsync(uri);

            return response;
        }

        /// <summary>
        /// Záskanie všetkých neobjednaných Vyšetrení užívateľa
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetVysetreniaNeobjednane()
        {
            string uri = $"https://localhost:5001/Vysetrenia/{User.Id}/Unapproved";

            var response = await WebApi.GetAsync(uri);

            return response;
        }

        /// <summary>
        /// Získanie konkrétneho vyšetrenia podľa jeho id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetVysetrenie(int id)
        {
            string uri = $"https://localhost:5001/Vysetrenia/{id}";

            var response = await WebApi.GetAsync(uri);

            return response;
        }

        /// <summary>
        /// Získanie všetkých časov voľných na dané vyšetrenie v danom dni
        /// </summary>
        /// <param name="idVysetrenia"></param>
        /// <param name="dayOfAppointment"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetCasyByDay(int idVysetrenia, DateTime dayOfAppointment)
        {
            string datum = dayOfAppointment.ToString("yyyyMMdd");
            string uri = $"https://localhost:5001/Vysetrenia/{idVysetrenia}/GetTimes/{datum}";

            var response = await WebApi.GetAsync(uri);

            return response;
        }

        /// <summary>
        /// Objednanie vyšetrenia na zadaný čas
        /// </summary>
        /// <param name="newTime"></param>
        /// <param name="vysetrenieId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ObjednavkaSetTime(DateTime newTime, int vysetrenieId)
        {
            string uri = "https://localhost:5001/Vysetrenia/AppointmentTime";
            
            var values = new
            {
                VysetrenieId = vysetrenieId,
                DateTime = newTime,
            };


            var response = await WebApi.PostAsJsonAsync(uri,values);

            return response;
        }

        /// <summary>
        /// Získanie všetkých vyšetrení užívateľa, ktoré sa stali v minulosti
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetHistoriaVysetreni()
        {
            string uri = $"https://localhost:5001/Vysetrenia/History/{User.Id}";
            var response = await WebApi.GetAsync(uri);
            return response;
        }

        public async Task<HttpResponseMessage> GetHistoriaOckovani()
        {
            string uri = $"https://localhost:5001/Vysetrenia/Ockovania/History/{User.Id}";
            var response = await WebApi.GetAsync(uri);
            return response;
        }
    }
}
