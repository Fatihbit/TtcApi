using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TtcApi.Data;
using TtcApi.Dtos;
using TtcApi.Models;

namespace TtcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TTCContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TTCContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("register-ship")]
        public async Task<IActionResult> RegisterShip([FromBody] ShipRegistrationDto registrationDto)
        {
            var user = new IdentityUser { UserName = registrationDto.Email, Email = registrationDto.Email };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var newShip = new Ship
            {
                ShipName = registrationDto.ShipName,
                Email = registrationDto.Email,
                Type = registrationDto.Type,
                UniekEuropeesScheepsidentificatienummer = registrationDto.UniekEuropeesScheepsidentificatienummer,
                Location = registrationDto.Location
            };

            _context.Ships.Add(newShip);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("register-terminal")]
        public async Task<IActionResult> RegisterTerminal([FromBody] TerminalRegistrationDto registrationDto)
        {
            var user = new IdentityUser { UserName = registrationDto.Email, Email = registrationDto.Email };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var newTerminal = new Terminal
            {
                TerminalName = registrationDto.TerminalName,
                Email = registrationDto.Email,
                Location = registrationDto.Location
            };

            _context.Terminals.Add(newTerminal);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid login attempt.");
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var ship = await _context.Ships.SingleOrDefaultAsync(s => s.Email == user.Email);
            if (ship != null)
            {
                HttpContext.Session.SetString("ShipName", ship.ShipName);
                HttpContext.Session.SetString("UserType", "Ship");
            }
            else
            {
                var terminal = await _context.Terminals.SingleOrDefaultAsync(t => t.Email == user.Email);
                if (terminal != null)
                {
                    HttpContext.Session.SetString("TerminalName", terminal.TerminalName);
                    HttpContext.Session.SetString("UserType", "Terminal");
                }
            }

            return Ok(new { Message = "Login successful" });
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not logged in.");
            }

            var ship = await _context.Ships.SingleOrDefaultAsync(s => s.Email.ToLower() == user.Email.ToLower());
            if (ship != null)
            {
                return Ok(new
                {
                    ShipName = ship.ShipName,
                    Email = ship.Email,
                    Type = ship.Type,
                    UniekEuropeesScheepsidentificatienummer = ship.UniekEuropeesScheepsidentificatienummer,
                    Location = ship.Location
                });
            }

            var terminal = await _context.Terminals.SingleOrDefaultAsync(t => t.Email.ToLower() == user.Email.ToLower());
            if (terminal != null)
            {
                return Ok(new
                {
                    TerminalName = terminal.TerminalName,
                    Email = terminal.Email,
                    Location = terminal.Location
                });
            }

            return BadRequest("Invalid user type.");
        }
    }
}
