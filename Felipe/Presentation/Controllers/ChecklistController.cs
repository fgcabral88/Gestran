using Felipe.Domain.Models;
using Felipe.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Felipe.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly ILogger<ChecklistController> _logger;

        public ChecklistController(SqlContext context, ILogger<ChecklistController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Returns all checklist data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checklist>>> GetChecklists()
        {
            return await _context.Checklists.Include(c => c.Items).ToListAsync();
        }

        /// <summary>
        /// Returns the checklist by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Checklist>> GetChecklist(int id)
        {
            var checklist = await _context.Checklists
                .Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);

            if (checklist == null)
            {
                return NotFound();
            }

            return checklist;
        }

        /// <summary>
        /// Checklist registration
        /// </summary>
        /// <param name="checklist">Checklist</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Checklist>> PostChecklist(Checklist checklist)
        {
            _context.Checklists.Add(checklist);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChecklist), new { id = checklist.Id }, checklist);
        }

        /// <summary>
        /// Change to the Checklist
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="checklist">Checklist</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecklist(int id, Checklist checklist)
        {
            if (id != checklist.Id)
                return BadRequest();

            _context.Entry(checklist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistExists(id))
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

        /// <summary>
        /// Delete the checklist
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChecklist(int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
                return NotFound();

            var hasRelatedItems = await _context.ChecklistItems.
                AnyAsync(item => item.Id == id);

            if (hasRelatedItems)
                return BadRequest(new
                {
                    message = "O dado não pode ser excluido, porque ele possui itens relacionados com a tabela 'ChecklistsItem'."
                });

            _context.Checklists.Remove(checklist);

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
                return NoContent();

            else
                return StatusCode(500, new
                {
                    message = "Ocorreu um erro inesperado ao tentar excluir o dado."
                });
        }

        /// <summary>
        /// Checklist execution
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="executorId">ExecutorId</param>
        /// <returns></returns>
        [HttpPost("start/{id}")]
        public async Task<IActionResult> StartChecklist(int id, int executorId)
        {
            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
                return NotFound();

            if (checklist.ExecutorId != null)
            {
                return Conflict(new
                {
                    message = "Este checklist já está sendo executado por outro executor."
                });
            }

            checklist.ExecutorId = executorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Complete checklist
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="executorId">ExecutorId</param>
        /// <returns></returns>
        [HttpPost("complete/{id}")]
        public async Task<IActionResult> CompleteChecklist(int id, int executorId)
        {
            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
                return NotFound();

            if (checklist.ExecutorId != executorId)
                return Unauthorized(new
                {
                    message = "Você não é o executor desse checklist de verificação."
                });

            checklist.ExecutorId = null;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ChecklistExists(int id)
        {
            return _context.Checklists.Any(e => e.Id == id);
        }
    }
}
