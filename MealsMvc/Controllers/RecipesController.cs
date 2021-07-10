using MealsMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealsMvc.Controllers
{
    public class RecipesController : Controller
    {
        private readonly MealsMvcContext _context;

        public RecipesController(MealsMvcContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (Recipe == null)
            {
                return NotFound();
            }

            return View(Recipe);
        }


    }
}
