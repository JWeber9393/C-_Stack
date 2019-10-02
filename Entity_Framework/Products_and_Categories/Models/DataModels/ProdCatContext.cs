using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Models
{
    public class ProdCatContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ProdCatContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Association> procats { get; set; }
    }
}