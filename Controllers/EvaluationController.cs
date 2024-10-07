using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackaton.Controllers
{
    [Route("api/evaluations")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EvaluationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/evaluations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations()
        {
            var evaluations = await _context.Evaluations
                                             .Include(e => e.Project)
                                             .Include(e => e.Mentor)
                                             .ToListAsync();

            return Ok(evaluations);
        }

        // GET: api/evaluations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluation>> GetEvaluation(int id)
        {
            var evaluation = await _context.Evaluations
                                           .Include(e => e.Project)
                                           .Include(e => e.Mentor)
                                           .FirstOrDefaultAsync(e => e.Id == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return Ok(evaluation);
        }

        // POST: api/evaluations
        [HttpPost]
        public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvaluation), new { id = evaluation.Id }, evaluation);
        }

        // PUT: api/evaluations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluation(int id, Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return BadRequest("Evaluation ID mismatch.");
            }

            _context.Entry(evaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(id))
                {
                    return NotFound("Evaluation not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/evaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound("Evaluation not found.");
            }

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.Id == id);
        }
    }
}
