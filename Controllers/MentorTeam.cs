using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/mentorteam")]
    [ApiController]
    [EnableCors("AllowReactApp")]

    public class MentorTeamController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MentorTeamController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MentorTeam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorTeam>>> GetMentorTeams()
        {
            return await _context.MentorTeams.ToListAsync(); 
        }

        // GET: api/MentorTeam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MentorTeam>> GetMentorTeam(int id)
        {
            var mentorTeam = await _context.MentorTeams.FindAsync(id); 

            if (mentorTeam == null)
            {
                return NotFound();
            }

            return mentorTeam;
        }

        // POST: api/MentorTeam
        [HttpPost]
        public async Task<ActionResult<MentorTeam>> PostMentorTeam(MentorTeam mentorTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MentorTeams.Add(mentorTeam);  
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMentorTeam), new { id = mentorTeam.Id }, mentorTeam);  
        }

        // PUT: api/MentorTeam/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMentorTeam(int id, MentorTeam mentorTeam)
        {
            if (id != mentorTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(mentorTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorTeamExists(id))
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

        // DELETE: api/MentorTeam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMentorTeam(int id)
        {
            var mentorTeam = await _context.MentorTeams.FindAsync(id); 
            if (mentorTeam == null)
            {
                return NotFound();
            }

            _context.MentorTeams.Remove(mentorTeam); 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MentorTeamExists(int id)
        {
            return _context.MentorTeams.Any(e => e.Id == id);
        }
    }
}
