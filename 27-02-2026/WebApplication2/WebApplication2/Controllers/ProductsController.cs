using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product{ Id=1,Name="Laptop",Price=50000},
            new Product{ Id=2,Name="Mobile",Price=25000},
            new Product{ Id=3,Name="Speaker",Price=5000}
        };

        public IActionResult Index()
        {
            return View(products);
        }
    }
}
