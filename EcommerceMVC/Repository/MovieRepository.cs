using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviedbContext _db;
        public MovieRepository(MoviedbContext db)
        {
            _db = db;
        }

        public List<TblMovie> GetAllMoviesAsync(string searchString)
        {

            //if(searchString is not null)
            //{
            //    var filterMovies = _db.TblMovies.Include("TblMovieCategory").Where(m=>m.Title.Contains(searchString)).ToList();
            //    return filterMovies;
            //}
            //return _db.TblMovies.Include("TblMovieCategory").ToList();
            if (searchString is not null)
            {
                var filterMovies = _db.TblMovies.Include(m=>m.Category).Where(m => m.Title.Contains(searchString)).ToList();
                return filterMovies;
            }
            return _db.TblMovies.Include(m=> m.Category).ToList();
        }
      
        public TblMovie AddMovieAsync(TblMovie movie)
        {
            var categoryExist = _db.TblMovieCategories.Where(c => c.Name == movie.Genre).FirstOrDefault();
            var categoryId = categoryExist.Id;

            movie.CategoryId = categoryId;

            _db.TblMovies.Add(movie);
            _db.SaveChanges();
            return movie;
            //var newMovie = _db.TblMovies.Add(movie);
            //_db.SaveChanges();
            //return newMovie.Entity;
        }

        public TblMovie GetMovieByIdAsync(string id)
        {
            var movie = _db.TblMovies.Where(m => m.Id == id).FirstOrDefault();
            return movie;
        }

        public TblMovie UpdateMovieAsync(string id, TblMovie movie)
        {
            var existingMovie = _db.TblMovies.Where(m => m.Id == id).FirstOrDefault();

            if (existingMovie is null)
            {
                return null;
            }
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Price = movie.Price;
            existingMovie.ReleaseDate = movie.ReleaseDate;

            _db.TblMovies.Update(existingMovie);
            _db.SaveChanges();

            return existingMovie;
        }

        public TblMovie DeleteMovieAsync(string id)
        {
            var existingMovie = _db.TblMovies.Where(m => m.Id == id).FirstOrDefault();
            if (existingMovie is null)
            {
                return null;
            }
            _db.TblMovies.Remove(existingMovie);
            _db.SaveChanges();
            return existingMovie;

        }
    }


}
