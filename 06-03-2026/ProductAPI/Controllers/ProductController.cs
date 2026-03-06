using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;
namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        // {
        //     return await _context.Products.ToListAsync();
        // }
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
    }
}