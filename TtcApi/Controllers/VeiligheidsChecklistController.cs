using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.DTOs;
using TtcApi.Repositories;
using TtcApi.Models;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiligheidsChecklistController : ControllerBase
    {
        private readonly IVeiligheidsChecklistRepository _repository;
        private readonly ILadingRepository _ladingRepository;

        public VeiligheidsChecklistController(IVeiligheidsChecklistRepository repository, ILadingRepository ladingRepository)
        {
            _repository = repository;
            _ladingRepository = ladingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiligheidsChecklistDTO>>> GetVeiligheidsChecklists()
        {
            var checklists = await _repository.GetVeiligheidsChecklistsAsync();
            return Ok(checklists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiligheidsChecklistDTO>> GetVeiligheidsChecklist(int id)
        {
            var checklist = await _repository.GetVeiligheidsChecklistByIdAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }
            return Ok(checklist);
        }

        [HttpPost]
        public async Task<ActionResult<VeiligheidsChecklistDTO>> PostVeiligheidsChecklist(VeiligheidsChecklistDTO dto)
        {
            var lading = await _ladingRepository.GetLadingByIdAsync(dto.LadingId);
            if (lading == null)
            {
                return BadRequest("Invalid LadingId");
            }

            await _repository.AddVeiligheidsChecklistAsync(dto);

            return CreatedAtAction(nameof(GetVeiligheidsChecklist), new { id = dto.VeiligheidsChecklistId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiligheidsChecklist(int id, VeiligheidsChecklistDTO dto)
        {
            if (id != dto.VeiligheidsChecklistId)
            {
                return BadRequest();
            }

            var checklist = await _repository.GetVeiligheidsChecklistByIdAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            var lading = await _ladingRepository.GetLadingByIdAsync(dto.LadingId);
            if (lading == null)
            {
                return BadRequest("Invalid LadingId");
            }

            await _repository.UpdateVeiligheidsChecklistAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiligheidsChecklist(int id)
        {
            var checklist = await _repository.GetVeiligheidsChecklistByIdAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            await _repository.DeleteVeiligheidsChecklistAsync(id);

            return NoContent();
        }

        [HttpGet("lading/{ladingId}")]
        public async Task<ActionResult<Lading>> GetLadingById(int ladingId)
        {
            var lading = await _ladingRepository.GetLadingByIdAsync(ladingId);
            if (lading == null)
            {
                return NotFound("Lading not found.");
            }

            return Ok(lading);
        }
    }
}
