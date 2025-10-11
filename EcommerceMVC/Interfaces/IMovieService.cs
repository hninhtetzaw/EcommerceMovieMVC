using MovieMVC.Models;

namespace MovieMVC.Interfaces;

public interface IMovieService
{
    List<ResponseMoviesModel> GetAllMovies(string searchString);
    ResponseMoviesModel AddMovie(RequestNewMovieModel request);
    ResponseMoviesModel GetMovieById(string id);
    ResponseMoviesModel UpdateMovie(string id, UpdateMovieModel movie);
    ResponseMoviesModel DeleteMovie(string id);
    

}
