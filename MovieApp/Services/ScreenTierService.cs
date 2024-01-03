using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class ScreenTierService : IScreenTierService
    {
        private readonly IAppContext _context;

        public ScreenTierService(IAppContext context)
        {
            _context = context;
        }

        public ScreenTier Add(ScreenTier request)
        {
            var result = _context.ScreenTiers.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public ScreenTier Update(ScreenTier request)
        {
            var result = _context.ScreenTiers.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.ScreenTiers.Remove(new ScreenTier { tier_ID = id });
            _context.SaveMyChanges();
        }

        public ScreenTier? Get(int id)
        {
            return _context.ScreenTiers.Where(x => x.tier_ID == id).FirstOrDefault();
        }

        public List<ScreenTier> GetAll()
        {
            var result = _context.ScreenTiers.ToList();
            return result;
        }

        public List<GenericDropdown> GetShortList()
        {
            var result = from item in _context.ScreenTiers
                         select new GenericDropdown
                         {
                             name = $"{item.tier_ID}",
                             value = $"{item.price}"
                         };
            return result.ToList();
        }
    }

    public interface IScreenTierService
    {
        ScreenTier Add(ScreenTier request);
        ScreenTier Update(ScreenTier request);
        void Delete(int id);
        ScreenTier? Get(int id);
        List<ScreenTier> GetAll();
        List<GenericDropdown> GetShortList();
    }
}
