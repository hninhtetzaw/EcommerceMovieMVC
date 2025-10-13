
using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Models;

namespace EcommerceMVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MoviedbContext _db;
        public CategoryRepository(MoviedbContext db)
        {
            _db = db;
        }

        public List<TblMovieCategory> GetAllCategoryAsync()
        {
            var lists = _db.TblMovieCategories.ToList();
            return lists;
        }
        public TblMovieCategory GetCategoryByIdAsync(string id)
        {
            return null;
        }
        public TblMovieCategory AddCategoryAsync(TblMovieCategory request)
        {

            _db.Add(request);
            _db.SaveChanges();

            return request;
        }

        public TblMovieCategory UpdateCategoryAsync(string id, TblMovieCategory request)
        {
            return null;
        }
        public TblMovieCategory DeleteCategoryAsync(string id)
        {
            return null;
        }
    }
}