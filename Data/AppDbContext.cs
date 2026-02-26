using Microsoft.EntityFrameworkCore;
using ProductSelling.Models;

namespace ProductSelling.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 999.99m, ImageUrl = "/images/laptop.png" },
                new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 799.99m, ImageUrl = "/images/smartphone.png" },
                new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling headphones", Price = 199.99m, ImageUrl = "/images/headphones.png" }
            );
        }
    }
}