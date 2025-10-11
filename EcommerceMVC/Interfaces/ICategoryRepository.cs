
using MovieMVC.Data;
using MovieMVC.Models;

namespace MovieMVC.Interfaces
{
    public interface ICategoryRepository
    {
        List<TblMovieCategory> GetAllCategoryAsync();
        TblMovieCategory GetCategoryByIdAsync(string id);
        TblMovieCategory AddCategoryAsync(TblMovieCategory movie);
        TblMovieCategory UpdateCategoryAsync(string id, TblMovieCategory movie);
        TblMovieCategory DeleteCategoryAsync(string id);
    }
}