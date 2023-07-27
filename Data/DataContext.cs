using api_a.Model;
using Microsoft.EntityFrameworkCore;

namespace api_a.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }




    }
}
