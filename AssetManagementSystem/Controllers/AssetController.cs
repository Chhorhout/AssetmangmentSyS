using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Controllers
{
    public class AssetController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AssetController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var assets = await _context.Assets.ToListAsync();
            return View(assets);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(Asset asset)
        {

            await _context.Assets.AddAsync(asset);

            await _context.SaveChangesAsync();

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return View(asset);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Asset asset)   
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
     
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
             _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  
        }
           
    

        

        

    }
}
