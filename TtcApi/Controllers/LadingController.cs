using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Dtos;
using TtcApi.Models;
using TtcApi.Repositories;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LadingController : ControllerBase
    {
        private readonly ILadingRepository _ladingRepository;

        public LadingController(ILadingRepository ladingRepository)
        {
            _ladingRepository = ladingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lading>>> GetLadings()
        {
            var ladings = await _ladingRepository.GetLadingsAsync();
            return Ok(ladings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lading>> GetLading(int id)
        {
            var lading = await _ladingRepository.GetLadingByIdAsync(id);
            if (lading == null)
            {
                return NotFound();
            }

            return Ok(lading);
        }

        [HttpPost]
        public async Task<ActionResult<Lading>> PostLading(LadingDto ladingDto)
        {
            var lading = new Lading
            {
                ShipName = ladingDto.ShipName,
                TerminalName = ladingDto.TerminalName,
                ProductName = ladingDto.ProductName,
                Datum = ladingDto.Datum,
                Tijd = ladingDto.Tijd,
                Hoeveelheid = ladingDto.Hoeveelheid
            };

            await _ladingRepository.AddLadingAsync(lading);

            return CreatedAtAction(nameof(GetLading), new { id = lading.LadingId }, lading);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLading(int id, LadingDto ladingDto)
        {
            var lading = new Lading
            {
                LadingId = id,
                ShipName = ladingDto.ShipName,
                TerminalName = ladingDto.TerminalName,
                ProductName = ladingDto.ProductName,
                Datum = ladingDto.Datum,
                Tijd = ladingDto.Tijd,
                Hoeveelheid = ladingDto.Hoeveelheid
            };

            await _ladingRepository.UpdateLadingAsync(id, lading);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLading(int id)
        {
            var lading = await _ladingRepository.GetLadingByIdAsync(id);
            if (lading == null)
            {
                return NotFound();
            }

            await _ladingRepository.DeleteLadingAsync(id);

            return NoContent();
        }
    }
}
