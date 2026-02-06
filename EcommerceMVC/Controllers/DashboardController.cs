using EcommerceMVC.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMovieService _service;
        public DashboardController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult UserDashboard(string? searchString)
        {
            var movielist = _service.GetAllMovies(searchString);
            return View(movielist);
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
