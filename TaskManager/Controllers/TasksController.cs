using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.Data;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TasksController(TaskManagerContext context)
        {
            _context = context;
        }

        // GET: api/CategoryTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTask>>> GetCategoryTask()
        {
          if (_context.CategoryTask == null)
          {
              return NotFound();
          }
            return await _context.CategoryTask.ToListAsync();
        }

        // GET: api/CategoryTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryTask>> GetCategoryTask(int id)
        {
          if (_context.CategoryTask == null)
          {
              return NotFound();
          }
            var categoryTask = await _context.CategoryTask.FindAsync(id);

            if (categoryTask == null)
            {
                return NotFound();
            }

            return categoryTask;
        }

        // PUT: api/CategoryTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryTask(int id, CategoryTask categoryTask)
        {
            if (id != categoryTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTaskExists(id))
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

        // POST: api/CategoryTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryTask>> PostCategoryTask(CategoryTask categoryTask)
        {
          if (_context.CategoryTask == null)
          {
              return Problem("Entity set 'TaskManagerContext.CategoryTask'  is null.");
          }
            _context.CategoryTask.Add(categoryTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryTask", new { id = categoryTask.Id }, categoryTask);
        }

        // DELETE: api/CategoryTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryTask(int id)
        {
            if (_context.CategoryTask == null)
            {
                return NotFound();
            }
            var categoryTask = await _context.CategoryTask.FindAsync(id);
            if (categoryTask == null)
            {
                return NotFound();
            }

            _context.CategoryTask.Remove(categoryTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryTaskExists(int id)
        {
            return (_context.CategoryTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
