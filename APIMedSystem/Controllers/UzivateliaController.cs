using System.Collections.Generic;
using System.Threading.Tasks;
using APIMedSystem.DBEF;
using APIMedSystem.DTOS.Uzivatel;
using Microsoft.AspNetCore.Mvc;
using APIMedSystem.Services.UzivateliaService;
using MedSystem.Database.Models;

namespace APIMedSystem.Controllers
{
    /// <summary>
    /// Api Controller, ktory prijímna requesty na danych endpointoch
    /// Každá operácia má v popise aj svoj príklad použita.
    /// Zatiaľ neobsahuje autentifikáciu ani autorizáciu
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class UzivateliaController : ControllerBase
    {
        private readonly IUzivateliaService _uzivateliaService;

        public UzivateliaController(IUzivateliaService uzivateliaService)
        {
            _uzivateliaService = uzivateliaService;
        }

        // GET: Uzivatelia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uzivatel>>> GetUzivatelia()
        {
            return Ok(await _uzivateliaService.GetAllUzivatelia());
        }

        // GET: Uzivatelia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uzivatel>> GetUzivatel(int id)
        {
            return Ok(await _uzivateliaService.GetUzivatelById(id));
        }

        // PUT: Uzivatelia
        [HttpPut]
        public async Task<IActionResult> PutUzivatel(UpdateUzivatelDto uzivatel)
        {
            ServiceResponse<GetUzivatelDto> response = await _uzivateliaService.UpdateUzivatel(uzivatel);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // POST: Uzivatelia
        [HttpPost]
        public async Task<ActionResult> PostUzivatel(AddUzivatelDto uzivatel)
        {
            var response = await _uzivateliaService.AddUzivatel(uzivatel);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        // DELETE: Uzivatelia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUzivatel(int id)
        {
            ServiceResponse<List<GetUzivatelDto>> response = await _uzivateliaService.DeleteUzivatel(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}
