// using AssetManagementSystem.Data;
// using AssetManagementSystem.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace AssetManagementSystem.Controllers;

// public class UserController : Controller
// {
//     private readonly ApplicationDbContext _context;

//     public UserController(ApplicationDbContext context)
//     {
//         _context = context;
//     }

    
//         public IActionResult Index()
//         {

//             var users = _context.Users.ToList();

//             return View(users);
//         }
//         [HttpGet]
//         public async Task<IActionResult> input()
//         {
//             return View();

//         }
//         [HttpPost]
//         public async Task<IActionResult> input(User user)
//         {

//             await _context.Users.AddAsync(user);

//             await _context.SaveChangesAsync();

//             return RedirectToAction(nameof(Index));
//         }   
//         [HttpGet]
//         public async Task<IActionResult> Update(Guid id)
//         {
//             var user = await _context.Users.FindAsync(id);
//             return View(user);
//         }
//         [HttpPost]
//         public async Task<IActionResult> Update(User user)
//         {
//             _context.Users.Update(user);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         [HttpGet]
//        public async Task<IActionResult> Delete(Guid id)
//         {
//             var user = await _context.Users.FindAsync(id);
//             if (user == null)
//             {
//                 return NotFound();
//             }
//              _context.Users.Remove(user);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));  
//         }
        
// }