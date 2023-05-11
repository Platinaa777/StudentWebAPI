using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
