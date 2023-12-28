using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class CustomerCredService : ICustomerCredService
    {
        private readonly IAppContext _context;

        public CustomerCredService(IAppContext context)
        {
            _context = context;
        }

        public CustomerCred Add(CustomerCred request)
        {
            var result = _context.CustomerCreds.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public CustomerCred Update(CustomerCred request)
        {
            var result = _context.CustomerCreds.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.CustomerCreds.Remove(new CustomerCred { customer_cred_ID = id });
            _context.SaveMyChanges();
        }

        public CustomerCred? Get(int id)
        {
            return _context.CustomerCreds.Where(x => x.customer_cred_ID == id).FirstOrDefault();
        }

        public List<CustomerCred> GetAll()
        {
            var result = _context.CustomerCreds.ToList();
            return result;
        }
    }

    public interface ICustomerCredService
    {
        CustomerCred Add(CustomerCred request);
        CustomerCred Update(CustomerCred request);
        void Delete(int id);
        CustomerCred? Get(int id);
        List<CustomerCred> GetAll();
    }
}
