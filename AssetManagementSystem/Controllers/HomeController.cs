using Microsoft.AspNetCore.Mvc;
using AssetManagementSystem.ViewModels;
using AssetManagementSystem.Data;
namespace AssetManagementSystem.Controllers

{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public IActionResult Index()
        {
            var dashboardVm = new DashboardVm();
            dashboardVm.TotalAssets = _context.Assets.Count();
            dashboardVm.TotalCategories = _context.Categories.Count();
            dashboardVm.TotalUsers = _context.Users.Count();
            dashboardVm.TotalMaintainer = _context.Maintainers.Count();
            return View(dashboardVm);

        }
    }
}
