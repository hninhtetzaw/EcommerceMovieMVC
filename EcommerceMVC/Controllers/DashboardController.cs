using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public IActionResult UserDashboard()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
