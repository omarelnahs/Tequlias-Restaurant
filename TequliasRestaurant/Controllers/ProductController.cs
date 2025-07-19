using Microsoft.AspNetCore.Mvc;
using TequliasRestaurant.Data;
using TequliasRestaurant.Models;

namespace TequliasRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> products;
        private Repository<Ingredient> ingredients;
        private Repository<Category> categories;

        public ProductController(ApplicationDbContext context)
        {
            products = new Repository<Product>(context);
            ingredients = new Repository<Ingredient>(context);
            categories = new Repository<Category>(context);
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Ingredients = await ingredients.GetAllAsync();
            ViewBag.Categories = await categories.GetAllAsync();
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Product());
            }
            else
            {
                ViewBag.Operation = "Edit";
                return View();
            }
            
        }
    }
}
