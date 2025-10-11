using MovieMVC.Data;
using MovieMVC.Interfaces;

namespace MovieMVC.Repository
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
            if(searchString is not null)
            {
                var filterMovies = _db.TblMovies.Where(m=>m.Title.Contains(searchString)).ToList();
                return filterMovies;
            }
            return _db.TblMovies.ToList();
        }
        public TblMovie AddMovieAsync(TblMovie movie)
        {

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
