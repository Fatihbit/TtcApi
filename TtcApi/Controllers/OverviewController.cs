using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TtcApi.Data;
using TtcApi.Models;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OverviewController : ControllerBase
{
    private readonly TTCContext _context;

    public OverviewController(TTCContext context)
    {
        _context = context;
    }

    [HttpGet("lading")]
    public async Task<ActionResult<IEnumerable<Lading>>> GetLadingsForUser()
    {
        var email = User.Identity.Name;
        var ladings = _context.Ladings
            .Where(l => l.Ship.Email == email) // Assuming Ship has an Email property
            .ToList();
        return Ok(ladings);
    }

    [HttpGet("veiligheidschecklist")]
    public async Task<ActionResult<IEnumerable<VeiligheidsChecklist>>> GetChecklistsForUser()
    {
        var email = User.Identity.Name;
        var checklists = _context.VeiligheidsChecklists
            .Where(vc => vc.Lading.Ship.Email == email) // Assuming Lading has a Ship and Ship has an Email property
            .ToList();
        return Ok(checklists);
    }
}
