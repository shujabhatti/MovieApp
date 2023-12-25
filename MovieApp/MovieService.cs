using Dapper;
using Microsoft.Extensions.Options;
using MovieApp.Model;
using System.Data.SqlClient;
using System.Linq;

namespace MovieApp
{
    public class MovieService : IMovieService
    {
        private string ConnectionString;

        public MovieService(IOptions<Configurations> _config)
        {
            try
            {
                ConnectionString = $"Data Source={_config.Value.Server} ;User ID= {_config.Value.UserName} ;Password= {_config.Value.Password} ;Initial Catalog= {_config.Value.Database}";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                else
                    throw;
            }
        }

        public void Add(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Execute("insert into movies (Name, Description) values (@Name, @Description)", new Dictionary<string, dynamic>
                {
                    { "@Name", movie.Name },
                    { "@Description", movie.Description }
                });
            }
        }

        public void Update(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Execute("update movies set Name = @Name, Description = @Description where Id = @Id", new Dictionary<string, dynamic>
                {
                    { "@Id", movie.Id },
                    { "@Name", movie.Name },
                    { "@Description", movie.Description }
                });
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Execute("delete from movies where Id = @Id", new Dictionary<string, dynamic> 
                { 
                    { "@Id", id } 
                });
            }
        }

        public Movie Get(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                return conn.Query<Movie>("select Id, Name, Description from movies where Id = @Id", new Dictionary<string, dynamic>
                {
                    { "@Id", id }
                }).ToList().FirstOrDefault();
            }
        }

        public List<Movie> GetAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                return conn.Query<Movie>("select Id, Name, Description from movies").ToList();
            }
        }
    }

    public interface IMovieService
    {
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        Movie Get(int id);
        List<Movie> GetAll();
    }
}
