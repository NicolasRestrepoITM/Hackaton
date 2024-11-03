using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/team")]
    [ApiController]
    [EnableCors("AllowReactApp")]
    public class TeamController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TeamController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // POST: api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        // GET: api/Team/Hackathon/5
        [HttpGet("hackathon/{hackathonId}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsByHackathon(int hackathonId)
        {
            return await _context.Teams
                .Where(t => t.HackathonId == hackathonId)
                .ToListAsync();
        }

        // POST: api/Team/AddParticipant
        [HttpPost("addparticipant")]
        public async Task<IActionResult> AddParticipantToTeam([FromBody] AddParticipantRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.Teams.FindAsync(request.TeamId);
            var participant = await _context.Participants.FindAsync(request.ParticipantId);

            if (team == null || participant == null)
            {
                return NotFound("Team or Participant not found.");
            }

            if (participant.TeamId.HasValue)
            {
                return BadRequest("Participant is already assigned to a team.");
            }

            participant.TeamId = request.TeamId;
            await _context.SaveChangesAsync();

            return Ok("Participant added to team successfully.");
        }
    }
    public class AddParticipantRequest
    {
        public int TeamId { get; set; }
        public int ParticipantId { get; set; }
    }
}