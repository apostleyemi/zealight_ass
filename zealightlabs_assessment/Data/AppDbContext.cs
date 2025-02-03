using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using zealightlabs_assessment.Entities;

namespace zealightlabs_assessment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Food" },
             new Category { Id = 2, Name = "Clothings" },
             new Category { Id = 3, Name = "Electronics" }
         );

            modelBuilder.Entity<Product>().HasData(
             new Product { Id = 1, Name = "Pizza", Description = "Delicious cheese pizza", Price = 9.99M, CategoryId = 1 },
            new Product { Id = 2, Name = "Burger", Description = "Juicy beef burger", Price = 5.99M, CategoryId = 1 },
            new Product { Id = 3, Name = "Pasta", Description = "Italian pasta with sauce", Price = 7.99M, CategoryId = 1 },
            new Product { Id = 4, Name = "Salad", Description = "Fresh vegetable salad", Price = 4.99M, CategoryId = 1 },
            new Product { Id = 5, Name = "Fried Chicken", Description = "Crispy fried chicken", Price = 8.99M, CategoryId = 1 },

            new Product { Id = 6, Name = "T-shirt", Description = "Cotton T-shirt", Price = 12.99M, CategoryId = 2 },
            new Product { Id = 7, Name = "Jeans", Description = "Comfortable denim jeans", Price = 29.99M, CategoryId = 2 },
            new Product { Id = 8, Name = "Jacket", Description = "Winter jacket", Price = 49.99M, CategoryId = 2 },
            new Product { Id = 9, Name = "Sweater", Description = "Warm wool sweater", Price = 39.99M, CategoryId = 2 },
            new Product { Id = 10, Name = "Skirt", Description = "Elegant skirt for women", Price = 22.99M, CategoryId = 2 },

            new Product { Id = 11, Name = "Laptop", Description = "High-performance laptop", Price = 799.99M, CategoryId = 3 },
            new Product { Id = 12, Name = "Smartphone", Description = "Latest smartphone with great features", Price = 699.99M, CategoryId = 3 },
            new Product { Id = 13, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99M, CategoryId = 3 },
            new Product { Id = 14, Name = "Smart Watch", Description = "Wearable fitness tracker", Price = 129.99M, CategoryId = 3 },
            new Product { Id = 15, Name = "TV", Description = "LED Smart TV with 4K resolution", Price = 499.99M, CategoryId = 3 },

            new Product { Id = 16, Name = "Pizza", Description = "Pepperoni pizza", Price = 10.99M, CategoryId = 1 },
            new Product { Id = 17, Name = "Sandwich", Description = "Chicken sandwich with veggies", Price = 6.49M, CategoryId = 1 },
            new Product { Id = 18, Name = "Ice Cream", Description = "Vanilla and chocolate ice cream", Price = 3.99M, CategoryId = 1 },
            new Product { Id = 19, Name = "Donut", Description = "Glazed donut", Price = 2.99M, CategoryId = 1 },
            new Product { Id = 20, Name = "Steak", Description = "Grilled steak", Price = 15.99M, CategoryId = 1 },

            new Product { Id = 21, Name = "Shorts", Description = "Casual summer shorts", Price = 18.99M, CategoryId = 2 },
            new Product { Id = 22, Name = "Blouse", Description = "Women's blouse", Price = 24.99M, CategoryId = 2 },
            new Product { Id = 23, Name = "Shoes", Description = "Leather shoes", Price = 59.99M, CategoryId = 2 },
            new Product { Id = 24, Name = "Dress", Description = "Formal dress", Price = 49.99M, CategoryId = 2 },
            new Product { Id = 25, Name = "Cap", Description = "Baseball cap", Price = 14.99M, CategoryId = 2 },

            new Product { Id = 26, Name = "Tablet", Description = "Android tablet", Price = 299.99M, CategoryId = 3 },
            new Product { Id = 27, Name = "Game Console", Description = "Gaming console with two controllers", Price = 399.99M, CategoryId = 3 },
            new Product { Id = 28, Name = "Speaker", Description = "Bluetooth portable speaker", Price = 89.99M, CategoryId = 3 },
            new Product { Id = 29, Name = "Camera", Description = "Digital camera with zoom", Price = 249.99M, CategoryId = 3 },
            new Product { Id = 30, Name = "Smart Bulb", Description = "LED smart bulb with remote control", Price = 19.99M, CategoryId = 3 }
            );
        }
    }
}
