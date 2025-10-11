using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieMVC.Data;
using MovieMVC.Interfaces;
using MovieMVC.Models;
using MovieMVC.Repository;

namespace MovieMVC.Services;
public class MovieService:IMovieService
{

    private readonly IMovieRepository _repo;
    public MovieService(IMovieRepository repo)
    {
        _repo = repo;
    }
    public List<ResponseMoviesModel> GetAllMovies(string searchString)
    {
        var lists = _repo.GetAllMoviesAsync(searchString);
        //select method forms a new list
        var responseList = lists.Select(m => new ResponseMoviesModel
        {           
            Id = m.Id,
            Title = m.Title,
            Genre = m.Genre,
            ReleaseDate = m.ReleaseDate,
            Price = m.Price
        }).ToList();

        return responseList;
    }

    public ResponseMoviesModel AddMovie(RequestNewMovieModel request)
    {
       var movie = new TblMovie
       {
           Id= request.Id,
           //Title = request.Title!,
           Title = request.Title,
           Genre = request.Genre,
           ReleaseDate = request.ReleaseDate,
           Price = request.Price
       };

        var response = _repo.AddMovieAsync(movie);

        var newMovie = new ResponseMoviesModel
        {
            Id = response.Id,
            Title = response.Title,
            Genre = response.Genre,
            ReleaseDate = response.ReleaseDate,
            Price = response.Price
        };

        return newMovie;      
    }

    public ResponseMoviesModel GetMovieById(string id)
    {
        if (id is null)
        {
            throw new ArgumentException("Invalid movie ID");
        }

        var movie = _repo.GetMovieByIdAsync(id);

        //map domain to model

        var response = new ResponseMoviesModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price
        };

        return response;
    }

    public ResponseMoviesModel UpdateMovie(string id, UpdateMovieModel request)
    {
        //map model to domain
        var movie = new TblMovie
        {
            Id = id,
            Title = request.Title,
            Genre = request.Genre,
            ReleaseDate = request.ReleaseDate,
            Price = request.Price
        };
        var existingMovie = _repo.UpdateMovieAsync(id, movie);

        if(existingMovie is null)
        {
            return null;
        }
        var response = new ResponseMoviesModel
        {
            Id = existingMovie.Id,
            Title = existingMovie.Title,
            Genre = existingMovie.Genre,
            ReleaseDate = existingMovie.ReleaseDate,
            Price = existingMovie.Price
        };
        return response;
    }

    public ResponseMoviesModel DeleteMovie(string id) {

        var result = _repo.DeleteMovieAsync(id);

        var response = new ResponseMoviesModel { 
            Id = result.Id,
            Title = result.Title,
            Genre = result.Genre,
            ReleaseDate = result.ReleaseDate,
            Price = result.Price
        };

        return response;

    }
}
