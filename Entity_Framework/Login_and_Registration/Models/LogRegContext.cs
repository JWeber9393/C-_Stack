using Microsoft.EntityFrameworkCore;

namespace Login_and_Registration.Models
{
    public class LogRegContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LogRegContext(DbContextOptions options) : base(options) { }

        public DbSet<RegUser> users { get; set; }
    }
}