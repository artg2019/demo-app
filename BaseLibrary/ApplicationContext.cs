using Microsoft.EntityFrameworkCore;

namespace demo_app
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ApplicationUser> Users {get; set;}
        public ApplicationContext()
        {
            Database.EnsureCreated();
        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=demo-app;Username=postgres;Password=admin");
        }
    }
    
}