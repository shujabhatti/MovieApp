using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class StaffService : IStaffService
    {
        private readonly IAppContext _context;

        public StaffService(IAppContext context)
        {
            _context = context;
        }

        public Staff Add(Staff request)
        {
            var result = _context.Staffs.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Staff Update(Staff request)
        {
            var result = _context.Staffs.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Staffs.Remove(new Staff { staff_ID = id });
            _context.SaveMyChanges();
        }

        public Staff? Get(int id)
        {
            return _context.Staffs.Where(x => x.staff_ID == id).FirstOrDefault();
        }

        public List<Staff> GetAll()
        {
            var result = _context.Staffs.ToList();
            return result;
        }
    }

    public interface IStaffService
    {
        Staff Add(Staff request);
        Staff Update(Staff request);
        void Delete(int id);
        Staff? Get(int id);
        List<Staff> GetAll();
    }
}
