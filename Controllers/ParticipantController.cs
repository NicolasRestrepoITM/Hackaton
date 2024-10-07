using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackaton.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ParticipantsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
        {
            var participants = await _context.Participants
                                              .Include(p => p.Team) // Incluir equipo relacionado
                                              .ToListAsync();

            return Ok(participants);
        }

        // GET: api/participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipant(int id)
        {
            var participant = await _context.Participants
                                             .Include(p => p.Team) // Incluir equipo relacionado
                                             .FirstOrDefaultAsync(p => p.Id == id);

            if (participant == null)
            {
                return NotFound("Participant not found.");
            }

            return Ok(participant);
        }

        // POST: api/participants
        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipant), new { id = participant.Id }, participant);
        }

        // PUT: api/participants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipant(int id, Participant participant)
        {
            if (id != participant.Id)
            {
                return BadRequest("Participant ID mismatch.");
            }

            _context.Entry(participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(id))
                {
                    return NotFound("Participant not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound("Participant not found.");
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(p => p.Id == id);
        }
    }
}
