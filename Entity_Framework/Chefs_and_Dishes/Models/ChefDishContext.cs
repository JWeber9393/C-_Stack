using Microsoft.EntityFrameworkCore;

namespace Chefs_and_Dishes.Models
{
    public class ChefDishContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ChefDishContext(DbContextOptions options) : base(options) { }

        //create tables
        //public DbSet<RegUser> users { get; set; } <-- like this!!!
        public DbSet<Chef> chefs { get; set; }
        public DbSet<Dish> dishes { get; set; }

        
    }
}