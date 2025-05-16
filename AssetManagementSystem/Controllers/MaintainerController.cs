// using AssetManagementSystem.Data;
// using AssetManagementSystem.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace AssetManagementSystem.Controllers;

// public class MaintainerController : Controller
// {
//     private readonly ApplicationDbContext _context;

//     public MaintainerController(ApplicationDbContext context)
//     {
//         _context = context;
//     }

    
//         public IActionResult Index()
//         {
//             var maintainers = _context.Maintainers.ToList();
//             return View(maintainers);
//         }
        
//         [HttpGet]
//         public async Task<IActionResult> Add()
//         {
//             return View();

//         }
//         [HttpPost]
//         public async Task<IActionResult> Add(Maintainer maintainer)
//         {

//             await _context.Maintainers.AddAsync(maintainer);

//             await _context.SaveChangesAsync();

//             return RedirectToAction(nameof(Index));
//         }   
//         [HttpGet]
//         public async Task<IActionResult> Update(Guid id)
//         {
//             var maintainer = await _context.Maintainers.FindAsync(id);
//             return View(maintainer);
//         }
//         [HttpPost]
//         public async Task<IActionResult> Update(Maintainer maintainer)
//         {
//             _context.Maintainers.Update(maintainer);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         [HttpGet]
//        public async Task<IActionResult> Delete(Guid id)
//         {
//             var maintainer = await _context.Maintainers.FindAsync(id);
//             if (maintainer == null)
//             {
//                 return NotFound();
//             }
//              _context.Maintainers.Remove(maintainer);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));  
//         }
        
// }