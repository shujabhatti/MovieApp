using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class StaffCredentialService : IStaffCredentialService
    {
        private readonly IAppContext _context;

        public StaffCredentialService(IAppContext context)
        {
            _context = context;
        }

        public StaffCredential Add(StaffCredential request)
        {
            var result = _context.StaffCredentials.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public StaffCredential Update(StaffCredential request)
        {
            var result = _context.StaffCredentials.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.StaffCredentials.Remove(new StaffCredential { staffcred_ID = id });
            _context.SaveMyChanges();
        }

        public StaffCredential? Get(int id)
        {
            return _context.StaffCredentials.Where(x => x.staffcred_ID == id).FirstOrDefault();
        }

        public List<StaffCredential> GetAll()
        {
            var result = _context.StaffCredentials.ToList();
            return result;
        }
    }

    public interface IStaffCredentialService
    {
        StaffCredential Add(StaffCredential request);
        StaffCredential Update(StaffCredential request);
        void Delete(int id);
        StaffCredential? Get(int id);
        List<StaffCredential> GetAll();
    }
}
