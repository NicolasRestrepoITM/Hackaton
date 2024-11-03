using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/organizer")]
    [ApiController]
    [EnableCors("AllowReactApp")]

    public class OrganizerController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrganizerController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Organizer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
            return await _context.Organizers.ToListAsync();  
        }

        // GET: api/Organizer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id); 

            if (organizer == null)
            {
                return NotFound();
            }

            return organizer;
        }

        // POST: api/Organizer
        [HttpPost]
        public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Organizers.Add(organizer);  
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganizer), new { id = organizer.Id }, organizer); 
        }

        // PUT: api/Organizer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(id))
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

        // DELETE: api/Organizer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            var organizer = await _context.Organizers.FindAsync(id); 
            if (organizer == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizer);  
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizerExists(int id)
        {
            return _context.Organizers.Any(e => e.Id == id);  
        }
    }
}
