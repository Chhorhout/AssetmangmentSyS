using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 5;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // public async Task<IActionResult> Index(int? page)
        // {
        //     int pageNumber = page ?? 1;
        //     var query = _context.Categories.AsNoTracking();
        //     var totalItems = await query.CountAsync();
        //     var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            
        //     var categories = await query
        //         .Skip((pageNumber - 1) * PageSize)
        //         .Take(PageSize)
        //         .ToListAsync();

        //     ViewBag.CurrentPage = pageNumber;
        //     ViewBag.TotalPages = totalPages;
        //     ViewBag.PageSize = PageSize;
        //     ViewBag.TotalItems = totalItems;

        //     return View("Index", categories);
        // }

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
            return RedirectToAction(nameof(Index));
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
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  
        }
    }
}
