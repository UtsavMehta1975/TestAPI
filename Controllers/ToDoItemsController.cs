// Controllers/ToDoItemsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToDoItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            // Fetches all ToDo items from the database asynchronously.
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            // Fetches a single ToDo item by its ID.
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null)
            {
                return NotFound(); // Returns 404 if the item is not found.
            }

            return item;
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem item)
        {
            // Adds a new ToDo item to the database.
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();

            // Returns a 201 Created response with the new item's location.
            return CreatedAtAction(nameof(GetToDoItem), new { id = item.Id }, item);
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest(); // Returns 400 if the ID in the URL and the item don't match.
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Returns 204 No Content on success.
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            // Finds the ToDo item by its ID.
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null)
            {
                return NotFound(); // Returns 404 if the item is not found.
            }

            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent(); // Returns 204 No Content on success.
        }
    }
}
