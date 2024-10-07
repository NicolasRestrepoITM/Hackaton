using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackaton.Controllers
{
    [Route("api/prizes")]
    [ApiController]
    public class PrizesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PrizesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/prizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prize>>> GetPrizes()
        {
            var prizes = await _context.Prizes
                                        .Include(p => p.Hackathon) // Incluir hackathon relacionado
                                        .ToListAsync();

            return Ok(prizes);
        }

        // GET: api/prizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prize>> GetPrize(int id)
        {
            var prize = await _context.Prizes
                                       .Include(p => p.Hackathon) // Incluir hackathon relacionado
                                       .FirstOrDefaultAsync(p => p.Id == id);

            if (prize == null)
            {
                return NotFound("Prize not found.");
            }

            return Ok(prize);
        }

        // POST: api/prizes
        [HttpPost]
        public async Task<ActionResult<Prize>> PostPrize(Prize prize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrize), new { id = prize.Id }, prize);
        }

        // PUT: api/prizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrize(int id, Prize prize)
        {
            if (id != prize.Id)
            {
                return BadRequest("Prize ID mismatch.");
            }

            _context.Entry(prize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrizeExists(id))
                {
                    return NotFound("Prize not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/prizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrize(int id)
        {
            var prize = await _context.Prizes.FindAsync(id);
            if (prize == null)
            {
                return NotFound("Prize not found.");
            }

            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrizeExists(int id)
        {
            return _context.Prizes.Any(p => p.Id == id);
        }
    }
}
