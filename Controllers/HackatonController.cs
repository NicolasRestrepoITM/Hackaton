using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/hackaton")]
    [ApiController]
    [EnableCors("AllowReactApp")]

    public class HackathonController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HackathonController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Hackathon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hackathon>>> GetHackathons()
        {
            return await _context.Hackathons.ToListAsync();
        }

        // GET: api/Hackathon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hackathon>> GetHackathon(int id)
        {
            var hackathon = await _context.Hackathons.FindAsync(id);

            if (hackathon == null)
            {
                return NotFound();
            }

            return hackathon;
        }

        // POST: api/Hackathon
        [HttpPost]
        public async Task<ActionResult<Hackathon>> PostHackathon(Hackathon hackathon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hackathons.Add(hackathon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHackathon), new { id = hackathon.Id }, hackathon);
        }

        // PUT: api/Hackathon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHackathon(int id, Hackathon hackathon)
        {
            if (id != hackathon.Id)
            {
                return BadRequest();
            }

            _context.Entry(hackathon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HackathonExists(id))
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

        // DELETE: api/Hackathon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHackathon(int id)
        {
            var hackathon = await _context.Hackathons.FindAsync(id);
            if (hackathon == null)
            {
                return NotFound();
            }

            _context.Hackathons.Remove(hackathon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HackathonExists(int id)
        {
            return _context.Hackathons.Any(e => e.Id == id);
        }
    }
}