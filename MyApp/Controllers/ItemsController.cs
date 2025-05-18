using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly MyAppContext _context;

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns>A list of items</returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        /// <summary>
        /// Gets an item by ID
        /// </summary>
        /// <param name="id">The ID of the item</param>
        /// <returns>The item details</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns>The created item</returns>
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        /// <summary>
        /// Updates an existing item
        /// </summary>
        /// <param name="id">The ID of the item to update</param>
        /// <param name="item">The updated item data</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            if (id != item.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Items.Any(e => e.Id == id)) return NotFound();
                throw;
            }
        }

        /// <summary>
        /// Deletes an item by ID
        /// </summary>
        /// <param name="id">The ID of the item to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}