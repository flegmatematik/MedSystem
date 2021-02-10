using System.Collections.Generic;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Osoba;
using Microsoft.AspNetCore.Mvc;
using APIMedSystem.Services.OsobyService;

namespace APIMedSystem.Controllers
{
    /// <summary>
    /// Api Controller, ktory prijímna requesty na danych endpointoch
    /// Každá operácia má v popise aj svoj príklad použita.
    /// Zatiaľ neobsahuje autentifikáciu ani autorizáciu
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class OsobyController : ControllerBase
    {
        private readonly IOsobyService _osobyService;

        public OsobyController(IOsobyService osobyService)
        {
            _osobyService = osobyService;
        }

        // GET: Osoby
        [HttpGet]
        public async Task<ActionResult> GetOsoba()
        {
            return Ok(await _osobyService.GetAllOsoby());
        }

        // GET: Osoby/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOsoba(int id)
        {
            return Ok(await _osobyService.GetOsobaById(id));
        }

        // PUT: Osoby/5
        [HttpPut]
        public async Task<IActionResult> PutOsoba(UpdateOsobaDto updatedOsoba)
        {
            ServiceResponse<GetOsobaDto> response = await _osobyService.UpdateOsoba(updatedOsoba);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        // POST: Osoby
        [HttpPost]
        public async Task<ActionResult> PostOsoba(AddOsobaDto novaOsoba)
        {
            return Ok(await _osobyService.AddOsoba(novaOsoba));
        }

        // DELETE: Osoby/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOsoba(int id)
        {
            ServiceResponse<List<GetOsobaDto>> response = await _osobyService.DeleteOsoba(id);

            return Ok(response);

        }
    }
}
