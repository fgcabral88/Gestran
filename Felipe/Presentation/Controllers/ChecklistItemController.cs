using Felipe.Domain.Models;
using Felipe.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Felipe.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistItemController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly ILogger<ChecklistItemController> _logger;

        public ChecklistItemController(SqlContext context, ILogger<ChecklistItemController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Returns all Checklist items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChecklistItem>>> GetChecklistItems()
        {
            return await _context.ChecklistItems.ToListAsync();
        }

        /// <summary>
        /// Returns Checklist items by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ChecklistItem>> GetChecklistItem(int id)
        {
            var checklistItem = await _context.ChecklistItems.FindAsync(id);

            if (checklistItem == null)
                return NotFound();

            return checklistItem;
        }

        /// <summary>
        /// Registration of Checklist items
        /// </summary>
        /// <param name="checklistItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ChecklistItem>> PostChecklistItem(ChecklistItem checklistItem)
        {
            _context.ChecklistItems.Add(checklistItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChecklistItem), new { id = checklistItem.Id }, checklistItem);
        }

        /// <summary>
        /// Change to checklist items
        /// </summary>
        /// <param name="checklistItem">ChecklistItem</param>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChecklistItem(int id, ChecklistItem checklistItem)
        {
            if (id != checklistItem.Id)
                return BadRequest();

            _context.Entry(checklistItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistItemExists(id))
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
        /// Delete a checklist item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChecklistItem(int id)
        {
            var checklistItem = await _context.ChecklistItems.FindAsync(id);

            if (checklistItem == null)
                return NotFound();

            _context.ChecklistItems.Remove(checklistItem);

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
                return NoContent();

            return StatusCode(500, new
            {
                message = "Ocorreu um erro inesperado ao tentar excluir o dado."
            });
        }

        private bool ChecklistItemExists(int id)
        {
            return _context.ChecklistItems.Any(e => e.Id == id);
        }
    }
}

