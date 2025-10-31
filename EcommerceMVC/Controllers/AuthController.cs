using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}
    }
}
