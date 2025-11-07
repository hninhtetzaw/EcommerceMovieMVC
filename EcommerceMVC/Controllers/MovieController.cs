using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using EcommerceMVC.Data;
using EcommerceMVC.Models;
using EcommerceMVC.Services;
using Mysqlx.Crud;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CategoryDtos;
using EcommerceMVC.Models.CombinedViewDto;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceMVC.Controllers
{
    [Authorize(Roles ="User")]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        private readonly ICategoryService _categoryService;
        public MovieController(IMovieService service,ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Movie/GetMovies
        [HttpGet]
        //[Authorize(Roles = "User")]
        //[HttpPost]
        public IActionResult GetMovies(string? searchString)
        { 
            var movies = _service.GetAllMovies(searchString);
            return View(movies);
        }

        //Movie/AddMovies
        //[HttpGet]
        //public IActionResult AddMovie()
        //{
        //    return View();
        //}

        //for categories dropdown list
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddMovie(string? searchString)
        {
            var categories = _categoryService.GetAllCategories();
            var addMovieModel = new AddMovieViewDto
            {
                MovieRequest = new RequestNewMovieModel(),
                CategoriesList = categories ?? new List<ResponseCategoryDto>()
            };

            return View(addMovieModel);
        }

        //Movie/AddMovies/
        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public IActionResult AddMovie([FromForm] AddMovieViewDto request)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var newMovieRequest = request.MovieRequest;
            var response = _service.AddMovie(newMovieRequest);

            //go back to getmovies pages
            return RedirectToAction("GetMovies");

        }
        //public IActionResult AddMovie([FromForm] RequestNewMovieModel request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var response = _service.AddMovie(request);

        //    //go back to getmovies pages
        //    return RedirectToAction("GetMovies");

        //}

        [HttpGet]
        //[Authorize(Roles = "Admin")]

        public IActionResult EditMovie(string id)
        {

            //var movie = _service.GetMovieById(id);
            //return View(movie);

            var movie = _service.GetMovieById(id);


            // Map the ResponseMoviesModel into UpdateMovieModel,
            // because the EditMovie view uses UpdateMovieModel
            // (this allows validation and form binding to work correctly)
            var model = new UpdateMovieModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate
            };
            return View(model);

        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public IActionResult UpdateMovie(string id, UpdateMovieModel request)
        {
            //for this , need to same in the view , so, i change the view to updatemoviemodel
            // If model validation fails, re-render the EditMovie view
            // with the same request model (so user sees their input + errors)

            if (!ModelState.IsValid)
            {
                return View("EditMovie",request);
            }
            var movie = _service.UpdateMovie(id, request);
            if(movie is null)
            {
                return NotFound();
            }
            return RedirectToAction("GetMovies");

        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]

        public IActionResult DeleteMovie(string id) 
        {
            var movie = _service.DeleteMovie(id);
            return RedirectToAction("GetMovies");
        }


        #region Users

        [HttpGet]
        //[HttpPost]
        public IActionResult GetMoviesUser(string? searchString)
        {
            var movies = _service.GetAllMovies(searchString);
            return View(movies);
        }

        #endregion
    }
}

