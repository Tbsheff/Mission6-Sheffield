using Microsoft.EntityFrameworkCore;

namespace Mission6_Sheffield.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<movies> Movies { get; set; }
    }
}
