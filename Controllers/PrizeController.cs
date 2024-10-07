using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/prize")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PrizeController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Prize
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prize>>> GetPrizes()
        {
            return await _context.Prizes.ToListAsync();
        }

        // GET: api/Prize/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prize>> GetPrize(int id)
        {
            var prize = await _context.Prizes.FindAsync(id);

            if (prize == null)
            {
                return NotFound();
            }

            return prize;
        }

        // POST: api/Prize
        [HttpPost]
        public async Task<ActionResult<Prize>> PostPrize(Prize prize)
        {
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrize), new { id = prize.Id }, prize);
        }

        // PUT: api/Prize/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrize(int id, Prize prize)
        {
            if (id != prize.Id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Prize/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrize(int id)
        {
            var prize = await _context.Prizes.FindAsync(id);
            if (prize == null)
            {
                return NotFound();
            }

            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrizeExists(int id)
        {
            return _context.Prizes.Any(e => e.Id == id);
        }

        // GET: api/Prize/ByHackathon/5
        [HttpGet("ByHackathon/{hackathonId}")]
        public async Task<ActionResult<IEnumerable<Prize>>> GetPrizesByHackathon(int hackathonId)
        {
            return await _context.Prizes
                .Where(p => p.HackathonId == hackathonId)
                .ToListAsync();
        }

        // GET: api/Prize/TopPrizes/5
        [HttpGet("TopPrizes/{count}")]
        public async Task<ActionResult<IEnumerable<Prize>>> GetTopPrizes(int count)
        {
            return await _context.Prizes
                .OrderByDescending(p => p.Id)  // Assuming newer prizes have higher IDs
                .Take(count)
                .ToListAsync();
        }
    }
}