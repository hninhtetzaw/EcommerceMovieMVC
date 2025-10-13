using EcommerceMVC.Data;

namespace EcommerceMVC.Interfaces.IRepositories
{
    public interface IMovieRepository
    {
        List<TblMovie> GetAllMoviesAsync(string searchString);
        TblMovie GetMovieByIdAsync(string id);
        TblMovie AddMovieAsync(TblMovie movie);
        TblMovie UpdateMovieAsync(string id, TblMovie movie);
        TblMovie DeleteMovieAsync(string id);
        //bool DeleteMovie(int id);

    }
}
