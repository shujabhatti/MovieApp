using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class ShowingService : IShowingService
    {
        private readonly IAppContext _context;

        public ShowingService(IAppContext context)
        {
            _context = context;
        }

        public Showing Add(Showing request)
        {
            var result = _context.Showings.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Showing Update(Showing request)
        {
            var result = _context.Showings.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Showings.Remove(new Showing { showing_ID = id });
            _context.SaveMyChanges();
        }

        public Showing? Get(int id)
        {
            return _context.Showings.Where(x => x.showing_ID == id).FirstOrDefault();
        }

        public List<Showing> GetAll()
        {
            var result = _context.Showings.ToList();
            return result;
        }
    }

    public interface IShowingService
    {
        Showing Add(Showing request);
        Showing Update(Showing request);
        void Delete(int id);
        Showing? Get(int id);
        List<Showing> GetAll();
    }
}
