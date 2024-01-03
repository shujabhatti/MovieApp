using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class SeatService : ISeatService
    {
        private readonly IAppContext _context;

        public SeatService(IAppContext context)
        {
            _context = context;
        }

        public Seat Add(Seat request)
        {
            var result = _context.Seats.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Seat Update(Seat request)
        {
            var result = _context.Seats.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Seats.Remove(new Seat { seat_ID = id });
            _context.SaveMyChanges();
        }

        public Seat? Get(int id)
        {
            return _context.Seats.Where(x => x.seat_ID == id).FirstOrDefault();
        }

        public List<Seat> GetAll()
        {
            var result = _context.Seats.ToList();
            return result;
        }

        public List<GenericDropdown> GetShortList()
        {
            var result = from item in _context.Seats
                         select new GenericDropdown
                         {
                             name = $"{item.seat_ID}",
                             value = $"{item.screen_ID} - {item.seat_type}"
                         };
            return result.ToList();
        }
    }

    public interface ISeatService
    {
        Seat Add(Seat request);
        Seat Update(Seat request);
        void Delete(int id);
        Seat? Get(int id);
        List<Seat> GetAll();
        List<GenericDropdown> GetShortList();
    }
}
