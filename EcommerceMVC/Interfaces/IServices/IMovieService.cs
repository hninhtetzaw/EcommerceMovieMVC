using EcommerceMVC.Models;

namespace EcommerceMVC.Interfaces.IServices;

public interface IMovieService
{
    List<ResponseMoviesModel> GetAllMovies(string searchString);
    ResponseMoviesModel AddMovie(RequestNewMovieModel request);
    ResponseMoviesModel GetMovieById(string id);
    ResponseMoviesModel UpdateMovie(string id, UpdateMovieModel movie);
    ResponseMoviesModel DeleteMovie(string id);


}
