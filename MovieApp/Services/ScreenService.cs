using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class ScreenService : IScreenService
    {
        private readonly IAppContext _context;

        public ScreenService(IAppContext context)
        {
            _context = context;
        }

        public Screen Add(Screen request)
        {
            var result = _context.Screens.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Screen Update(Screen request)
        {
            var result = _context.Screens.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Screens.Remove(new Screen { screen_ID = id });
            _context.SaveMyChanges();
        }

        public Screen? Get(int id)
        {
            return _context.Screens.Where(x => x.screen_ID == id).FirstOrDefault();
        }

        public List<Screen> GetAll()
        {
            var result = _context.Screens.ToList();
            return result;
        }

        public List<GenericDropdown> GetShortList()
        {
            var result = from item in _context.Screens
                         select new GenericDropdown
                         {
                             name = $"{item.screen_ID}",
                             value = $"{item.sc_tier_ID} - {item.capacity}"
                         };
            return result.ToList();
        }
    }

    public interface IScreenService
    {
        Screen Add(Screen request);
        Screen Update(Screen request);
        void Delete(int id);
        Screen? Get(int id);
        List<Screen> GetAll();
        List<GenericDropdown> GetShortList();
    }
}
