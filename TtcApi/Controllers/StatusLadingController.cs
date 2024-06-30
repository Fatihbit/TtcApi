using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Repositories;
using Microsoft.Extensions.Logging;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusLadingController : ControllerBase
    {
        private readonly IStatusLadingRepository _statusLadingRepository;
        private readonly ILadingRepository _ladingRepository;
        private readonly ILogger<StatusLadingController> _logger;

        public StatusLadingController(IStatusLadingRepository statusLadingRepository, ILadingRepository ladingRepository, ILogger<StatusLadingController> logger)
        {
            _statusLadingRepository = statusLadingRepository;
            _ladingRepository = ladingRepository;
            _logger = logger;
        }

        [HttpGet("ByTerminal")]
        public async Task<ActionResult<IEnumerable<Lading>>> GetStatusLadingsByTerminal()
        {
            var terminalName = HttpContext.Session.GetString("TerminalName");
            if (string.IsNullOrEmpty(terminalName))
            {
                _logger.LogWarning("Unauthorized access attempt without terminal session.");
                return Unauthorized("User not logged in as Terminal.");
            }

            _logger.LogInformation("Fetching ladings for terminal: {TerminalName}", terminalName);
            var ladings = await _ladingRepository.GetLadingsByTerminalNameAsync(terminalName);
            return Ok(ladings);
        }

        [HttpGet("ByShip")]
        public async Task<ActionResult<IEnumerable<object>>> GetStatusLadingsByShip()
        {
            var shipName = HttpContext.Session.GetString("ShipName");
            if (string.IsNullOrEmpty(shipName))
            {
                _logger.LogWarning("Unauthorized access attempt without ship session.");
                return Unauthorized("User not logged in as Ship.");
            }

            _logger.LogInformation("Fetching ladings for ship: {ShipName}", shipName);
            var ladings = await _ladingRepository.GetLadingsByShipNameAsync(shipName);
            var statusLadings = new List<object>();

            foreach (var lading in ladings)
            {
                var statusLading = await _statusLadingRepository.GetStatusLadingByLadingIdAsync(lading.LadingId);
                statusLadings.Add(new
                {
                    lading.LadingId,
                    lading.ProductName,
                    lading.ShipName,
                    lading.TerminalName,
                    lading.Hoeveelheid,
                    lading.Datum,
                    lading.Tijd,
                    Status = statusLading?.IsAccepted,
                    Reason = statusLading?.Reason
                });
            }

            return Ok(statusLadings);
        }

        [HttpPost("ApproveLading")]
        public async Task<IActionResult> ApproveLading([FromBody] ApprovalRequest approvalRequest)
        {
            var statusLading = await _statusLadingRepository.GetStatusLadingByLadingIdAsync(approvalRequest.LadingId);
            if (statusLading == null)
            {
                statusLading = new StatusLading
                {
                    LadingId = approvalRequest.LadingId,
                    IsAccepted = approvalRequest.IsApproved,
                    Reason = approvalRequest.Reason
                };
                await _statusLadingRepository.AddStatusLadingAsync(statusLading);
            }
            else
            {
                statusLading.IsAccepted = approvalRequest.IsApproved;
                statusLading.Reason = approvalRequest.Reason;
                await _statusLadingRepository.UpdateStatusLadingAsync(statusLading);
            }

            return NoContent();
        }
    }

    public class ApprovalRequest
    {
        public int LadingId { get; set; }
        public bool IsApproved { get; set; }
        public string Reason { get; set; }
    }
}
