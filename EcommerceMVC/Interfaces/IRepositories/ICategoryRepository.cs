using EcommerceMVC.Data;
using EcommerceMVC.Models;

namespace EcommerceMVC.Interfaces.IRepositories
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