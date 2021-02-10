using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using APIMedSystem.DTOS.Vysetrenie;
using APIMedSystem.Services.VysetreniaService;

namespace APIMedSystem.Controllers
{
    /// <summary>
    /// Api Controller, ktory prijímna requesty na danych endpointoch
    /// Každá operácia má v popise aj svoj príklad použita.
    /// Zatiaľ neobsahuje autentifikáciu ani autorizáciu
    /// </summary>

    [Route("[controller]")]
    [ApiController]
    public class VysetreniaController : ControllerBase
    {
        private readonly IVysetreniaService _vysetreniaService;

        public VysetreniaController(IVysetreniaService vysetreniaService)
        {
            _vysetreniaService = vysetreniaService;
        }

        // GET: Vysetrenia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetVysetrenia()
        {
            return Ok(await _vysetreniaService.GetAllVysetrenia());
        }

        // GET: Vysetrenia/Osoba/5
        [HttpGet("Osoba/{osobaId}")]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetVysetreniaByOsobaId(int osobaId)
        {
            return Ok(await _vysetreniaService.GetVysetreniaByOsobaId(osobaId));
        }

        // GET: Vysetrenia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetVysetrenieDto>> GetVysetrenieById(int id)
        {
            return Ok(await _vysetreniaService.GetVysetrenieById(id));
        }

        // GET: Vysetrenia/5/20211231240000
        [HttpGet("{osobaId}/{lastDate}")]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetVysetreniaByOsobaIdByDateTime(int osobaId, string lastDate)
        {
            DateTime date = DateTime.ParseExact(lastDate, "yyyyMMddHHmmss",CultureInfo.InvariantCulture);
            return Ok(await _vysetreniaService.GetVysetreniaByOsobaIdByDateTime(osobaId, date));
        }

        // GET: Vysetrenia/5/Unapproved
        [HttpGet("{osobaId}/Unapproved")]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetUnapprovedVysetrenia(int osobaId)
        {
            return Ok(await _vysetreniaService.GetUnapprovedVysetrenia(osobaId));
        }

        // POST: Vysetrenia
        [HttpPost]
        public async Task<ActionResult<GetVysetrenieDto>> AddVysetrenie(AddVysetrenieDto noveVysetrenie)
        {
            return Ok(await _vysetreniaService.AddVysetrenie(noveVysetrenie));
        }

        // GET: Vysetrenia/5/GetTimes/20210111
        [HttpGet("{idVysetrenia}/GetTimes/{datum}")]
        public async Task<ActionResult<IEnumerable<string>>> GetTimes(int idVysetrenia, string datum)
        {
            DateTime date = DateTime.ParseExact(datum, "yyyyMMdd", CultureInfo.InvariantCulture);
            return Ok(await _vysetreniaService.GetAppointmentTimes(idVysetrenia, date));
        }

        // POST: Vysetrenia/AppointmentTime
        [HttpPost("AppointmentTime")]
        public async Task<ActionResult<GetVysetrenieDto>> SetAppointmentTime(SetTimeVysetrenieDto objednanyCas)
        {
            return Ok(await _vysetreniaService.SetAppointmentTime(objednanyCas));
        }

        // GET: Vysetrenia/History/5
        [HttpGet("History/{osobaId}")]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetHistory(int osobaId)
        {
            return Ok(await _vysetreniaService.GetHistory(osobaId));
        }

        // GET: Vysetrenia/History/5
        [HttpGet("Ockovania/History/{osobaId}")]
        public async Task<ActionResult<IEnumerable<GetVysetrenieDto>>> GetOckovania(int osobaId)
        {
            return Ok(await _vysetreniaService.GetOckovaniaHistory(osobaId));
        }
    }
}
