using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
