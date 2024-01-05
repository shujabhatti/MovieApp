using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IAppContext _context;

        public MovieService(IAppContext context)
        {
            _context = context;
        }

        public Movie Add(Movie request)
        {
            var result = _context.Movies.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Movie Update(Movie request)
        {
            var result = _context.Movies.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Movies.Remove(new Movie { movie_ID = id });
            _context.SaveMyChanges();
        }

        public Movie? Get(int id)
        {
            return _context.Movies.Where(x => x.movie_ID == id).FirstOrDefault();
        }

        public List<Movie> GetAll()
        {
            var result = _context.Movies.ToList();
            return result;
        }

        public List<GenericDropdown> GetShortList()
        {
            var result = from item in _context.Movies
                         select new GenericDropdown
                         {
                             name = $"{item.movie_ID}",
                             value = item.title
                         };
            return result.ToList();
        }
    }

    public interface IMovieService
    {
        Movie Add(Movie request);
        Movie Update(Movie request);
        void Delete(int id);
        Movie? Get(int id);
        List<Movie> GetAll();
        List<GenericDropdown> GetShortList();
    }
}
