using MovieApp.Data;
using MovieApp.Model;

namespace MovieApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly IAppContext _context;

        public TicketService(IAppContext context)
        {
            _context = context;
        }

        public Ticket Add(Ticket request)
        {
            var result = _context.Tickets.Add(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public Ticket Update(Ticket request)
        {
            var result = _context.Tickets.Update(request).Entity;
            _context.SaveMyChanges();
            return result;
        }

        public void Delete(int id)
        {
            _context.Tickets.Remove(new Ticket { ticket_ID = id });
            _context.SaveMyChanges();
        }

        public Ticket? Get(int id)
        {
            return _context.Tickets.Where(x => x.ticket_ID == id).FirstOrDefault();
        }

        public List<Ticket> GetAll()
        {
            var result = _context.Tickets.ToList();
            return result;
        }
    }

    public interface ITicketService
    {
        Ticket Add(Ticket request);
        Ticket Update(Ticket request);
        void Delete(int id);
        Ticket? Get(int id);
        List<Ticket> GetAll();
    }
}
