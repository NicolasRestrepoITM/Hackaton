using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Hackaton.Models;
using Hackaton.Database;

namespace Hackaton.Controllers
{
    [Route("api/project")]
    [ApiController]
    [EnableCors("AllowReactApp")]

    public class ProjectController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProjectController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el TeamId existe
            var teamExists = await _context.Teams.AnyAsync(t => t.Id == project.TeamId);
            if (!teamExists)
            {
                return BadRequest($"El equipo con ID {project.TeamId} no existe.");
            }

            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Npgsql.PostgresException pgEx && pgEx.SqlState == "23503")
                {
                    return BadRequest($"No se pudo crear el proyecto. Asegúrate de que el TeamId ({project.TeamId}) exista.");
                }
                throw;
            }

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

        // GET: api/Project/Team/5
        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<Project>> GetProjectByTeam(int teamId)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.TeamId == teamId);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Project/5/UpdateStatus
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> UpdateProjectStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NewStatus))
            {
                return BadRequest("El nuevo estado no puede ser nulo o estar vacío.");
            }

            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound($"No se encontró un proyecto con ID {id}.");
            }

            project.DevelopmentStatus = request.NewStatus.Trim();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                return StatusCode(500, "Ocurrió un error al actualizar el estado del proyecto. Por favor, inténtelo de nuevo." + ex);
            }

            return Ok($"Estado del proyecto actualizado exitosamente a '{project.DevelopmentStatus}'.");
        }
    }

    public class UpdateStatusRequest
    {
        public string? NewStatus { get; set; }
    }
}