using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApp.Model;

namespace MovieApp.Data
{
    public interface IAppContext
    {
        DbSet<CustomerCred> CustomerCreds { get; set; }
        DbSet<MyCustomer> MyCustomers { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<SeatType> SeatTypes { get; set; }
        DbSet<Screen> Screens { get; set; }
        DbSet<ScreenTier> ScreenTiers { get; set; }
        DbSet<Showing> Showings { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<StaffCredential> StaffCredentials { get; set; }
        DbSet<Movie> Movies { get; set; }
        int SaveMyChanges();
    }

    public class MovieAppContext : DbContext, IAppContext
    {
        public DbSet<CustomerCred> CustomerCreds { get; set; } = null!;
        public DbSet<MyCustomer> MyCustomers { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<SeatType> SeatTypes { get; set; } = null!;
        public DbSet<Screen> Screens { get; set; } = null!;
        public DbSet<ScreenTier> ScreenTiers { get; set; } = null!;
        public DbSet<Showing> Showings { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<StaffCredential> StaffCredentials { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        
        private string ConnectionString;

        public MovieAppContext(IOptions<Configurations> _config)
        {
            try
            {
                ConnectionString = $"DATA SOURCE={_config.Value.Server}/{_config.Value.Database}; PERSIST SECURITY INFO=True;USER ID={_config.Value.UserName}; password={_config.Value.Password}; Pooling=False;";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                else
                    throw;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseOracle(ConnectionString);

        public int SaveMyChanges() => base.SaveChanges();
    }
}
