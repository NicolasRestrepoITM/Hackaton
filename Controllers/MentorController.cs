using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/mentor")]
    [ApiController]
    [EnableCors("AllowReactApp")]

    public class MentorController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MentorController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Mentor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mentor>>> GetMentores()
        {
            return await _context.Mentors.ToListAsync();  
        }

        // GET: api/Mentor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentor(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);  

            if (mentor == null)
            {
                return NotFound();
            }

            return mentor;
        }

        // POST: api/Mentor
        [HttpPost]
        public async Task<ActionResult<Mentor>> PostMentor(Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mentors.Add(mentor);  
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMentor), new { id = mentor.Id }, mentor);  
        }

        // PUT: api/Mentor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMentor(int id, Mentor mentor)
        {
            if (id != mentor.Id)
            {
                return BadRequest();
            }

            _context.Entry(mentor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorExists(id))
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

        // DELETE: api/Mentor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMentor(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);  
            if (mentor == null)
            {
                return NotFound();
            }

            _context.Mentors.Remove(mentor);  
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MentorExists(int id)
        {
            return _context.Mentors.Any(e => e.Id == id);  
        }
    }
}
