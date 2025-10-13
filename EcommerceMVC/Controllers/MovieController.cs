using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using EcommerceMVC.Data;
using EcommerceMVC.Models;
using EcommerceMVC.Services;
using Mysqlx.Crud;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using EcommerceMVC.Interfaces.IServices;

namespace EcommerceMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Movie/GetMovie
        [HttpGet]
        //[HttpPost]
        public IActionResult GetMovies(string? searchString)
        { 
            var movies = _service.GetAllMovies(searchString);
            return View(movies);
        }

        //Movie/AddMovies
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //Movie/AddMovies/
        [HttpPost]
        public IActionResult AddMovie(RequestNewMovieModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = _service.AddMovie(request);

            //go back to getmovies pages
            return RedirectToAction("GetMovies");

        }

        [HttpGet]
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
        public IActionResult DeleteMovie(string id) 
        {
            var movie = _service.DeleteMovie(id);
            return RedirectToAction("GetMovies");
        }


    }
}
