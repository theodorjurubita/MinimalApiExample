using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Persistence
{
    public class EndpointsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MinimalApiDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new Car { Id = 1, Make = "BMW", Model = "320d" });
            modelBuilder.Entity<Car>().HasData(new Car { Id = 2, Make = "BMW", Model = "420d" });
        }

        public DbSet<Car> Cars { get; set; }
    }
}
