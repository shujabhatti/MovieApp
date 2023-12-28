using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAppContext _context;

        public CustomerService(IAppContext context)
        {
            _context = context;
        }

        public MyCustomer Add(MyCustomer request)
        {
            var result = _context.MyCustomers.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public MyCustomer Update(MyCustomer request)
        {
            var result = _context.MyCustomers.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.MyCustomers.Remove(new MyCustomer { customer_ID = id });
            _context.SaveMyChanges();
        }

        public MyCustomer? Get(int id)
        {
            return _context.MyCustomers.Where(x => x.customer_ID == id).FirstOrDefault();
        }

        public List<MyCustomer> GetAll()
        {
            var result = _context.MyCustomers.ToList();
            return result;
        }
    }

    public interface ICustomerService
    {
        MyCustomer Add(MyCustomer request);
        MyCustomer Update(MyCustomer request);
        void Delete(int id);
        MyCustomer? Get(int id);
        List<MyCustomer> GetAll();
    }
}
