using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var categories = _context.Categories.ToList();

            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Add(Category categories)
        {

            await _context.Categories.AddAsync(categories);

            await _context.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
        

    }
}
