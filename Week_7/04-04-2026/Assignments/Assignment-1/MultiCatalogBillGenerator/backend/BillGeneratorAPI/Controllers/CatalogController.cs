using BillGeneratorAPI.Data;
using BillGeneratorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillGeneratorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.CatalogItems.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{catalogType}")]
        public async Task<IActionResult> GetByType(string catalogType)
        {
            if (!Enum.TryParse<CatalogType>(catalogType, true, out var parsedType))
            {
                return BadRequest("Invalid catalog type.");
            }

            var items = await _context.CatalogItems
                .Where(x => x.CatalogType == parsedType)
                .ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CatalogItem item)
        {
            _context.CatalogItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] CatalogItem updatedItem)
        {
            var item = await _context.CatalogItems.FindAsync(id);

            if (item == null)
            {
                return NotFound(new { message = "Catalog item not found." });
            }

            item.Name = updatedItem.Name;
            item.Price = updatedItem.Price;
            item.CatalogType = updatedItem.CatalogType;
            item.IsVariablePrice = updatedItem.IsVariablePrice;

            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.CatalogItems.FindAsync(id);

            if (item == null)
            {
                return NotFound(new { message = "Catalog item not found." });
            }

            _context.CatalogItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Catalog item deleted successfully." });
        }
    }
}