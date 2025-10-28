using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
