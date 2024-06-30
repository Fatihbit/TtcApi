using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TtcApi.Models;
using TtcApi.Repositories;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipRepository _shipRepository;

        public ShipController(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        // GET: api/Ship
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ship>>> GetShips()
        {
            var ships = await _shipRepository.GetShipsAsync();
            return Ok(ships);
        }

        // GET: api/Ship/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetShip(string id)
        {
            var ship = await _shipRepository.GetShipAsync(id);
            if (ship == null)
            {
                return NotFound();
            }

            return Ok(ship);
        }

        // POST: api/Ship
        [HttpPost]
        public async Task<ActionResult> AddShip(Ship ship)
        {
            await _shipRepository.AddShipAsync(ship);
            return CreatedAtAction(nameof(GetShip), new { id = ship.ShipName }, ship);
        }

        // PUT: api/Ship/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateShip(string id, Ship ship)
        {
            if (id != ship.ShipName)
            {
                return BadRequest();
            }

            await _shipRepository.UpdateShipAsync(ship);
            return NoContent();
        }

        // DELETE: api/Ship/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShip(string id)
        {
            await _shipRepository.DeleteShipAsync(id);
            return NoContent();
        }

        // PUT: api/Ship/UpdateLocation
        [HttpPut("UpdateLocation")]
        [Authorize]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationDto updateLocationDto)
        {
            var email = User.Identity.Name;
            var ship = await _shipRepository.GetShipByEmailAsync(email);
            if (ship == null)
            {
                return NotFound("Ship not found.");
            }

            ship.Location = updateLocationDto.Location;
            await _shipRepository.UpdateShipAsync(ship);

            return NoContent();
        }
    }

    public class UpdateLocationDto
    {
        public string Location { get; set; }
    }
}
