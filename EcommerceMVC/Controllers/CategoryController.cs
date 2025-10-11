using Microsoft.AspNetCore.Mvc;
using MovieMVC.Interfaces;
using MovieMVC.Models;
using MovieMVC.Service;

namespace MovieMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var results = _service.GetAllCategories();
            ViewBag.Count = results.Count();
            return View(results);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(RequestNewCategoryDto request) 
        {
            var result = _service.AddCategory(request);
            var count = result.ToString().Length;  
            ViewBag.Count = count;
            return RedirectToAction("GetCategories", "Category");
        }
    }
}