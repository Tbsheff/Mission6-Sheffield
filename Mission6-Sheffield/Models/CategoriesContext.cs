using Microsoft.EntityFrameworkCore;

namespace Mission6_Sheffield.Models
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options)
        {
        }

        // DbSet property for Categories entity
        public DbSet<Categories> Categories { get; set; }
    }
}
