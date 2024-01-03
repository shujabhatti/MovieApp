using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly IAppContext _context;

        public SeatTypeService(IAppContext context)
        {
            _context = context;
        }

        public SeatType Add(SeatType request)
        {
            var result = _context.SeatTypes.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public SeatType Update(SeatType request)
        {
            var result = _context.SeatTypes.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.SeatTypes.Remove(new SeatType { type_ID = id });
            _context.SaveMyChanges();
        }

        public SeatType? Get(int id)
        {
            return _context.SeatTypes.Where(x => x.type_ID == id).FirstOrDefault();
        }

        public List<SeatType> GetAll()
        {
            var result = _context.SeatTypes.ToList();
            return result;
        }

        public List<GenericDropdown> GetShortList()
        {
            var result = from item in _context.SeatTypes
                         select new GenericDropdown
                         {
                             name = $"{item.type_ID}",
                             value = item.name
                         };
            return result.ToList();
        }
    }

    public interface ISeatTypeService
    {
        SeatType Add(SeatType request);
        SeatType Update(SeatType request);
        void Delete(int id);
        SeatType? Get(int id);
        List<SeatType> GetAll();
        List<GenericDropdown> GetShortList();
    }
}
