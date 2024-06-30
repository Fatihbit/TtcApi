using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Repositories;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalRepository _terminalRepository;

        public TerminalController(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;
        }

        // GET: api/Terminal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terminal>>> GetTerminals()
        {
            var terminals = await _terminalRepository.GetTerminalsAsync();
            return Ok(terminals);
        }

        // GET: api/Terminal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Terminal>> GetTerminal(string id)
        {
            var terminal = await _terminalRepository.GetTerminalAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }

            return Ok(terminal);
        }

        // POST: api/Terminal
        [HttpPost]
        public async Task<ActionResult> AddTerminal(Terminal terminal)
        {
            await _terminalRepository.AddTerminalAsync(terminal);
            return CreatedAtAction(nameof(GetTerminal), new { id = terminal.TerminalName }, terminal);
        }

        // PUT: api/Terminal/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTerminal(string id, Terminal terminal)
        {
            if (id != terminal.TerminalName)
            {
                return BadRequest();
            }

            await _terminalRepository.UpdateTerminalAsync(terminal);
            return NoContent();
        }

        // DELETE: api/Terminal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTerminal(string id)
        {
            await _terminalRepository.DeleteTerminalAsync(id);
            return NoContent();
        }
    }
}
