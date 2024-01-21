#nullable disable
using Microsoft.EntityFrameworkCore;
using BeautyClinicApi.Models;

namespace BeautyClinicApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePhoto)
                .IsRequired(false);

        }

        public static class SeedData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServiceProvider = scope.ServiceProvider;
                    var context = scopedServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Look for any existing data.
                    if (context.Products.Any() || context.Categories.Any())
                    {
                        return; // DB has been seeded
                    }

                    // Seed users
                    context.Users.AddRange(
                        new User { Username = "user1", Email = "user1@example.com", Password = "Password1", FullName = "User One", Role = "Client" },
                        new User { Username = "user2", Email = "user2@example.com", Password = "Password2", FullName = "User Two", Role = "Client" },
                        new User { Username = "admin", Email = "admin@example.com", Password = "admin2", FullName = "admin a", Role = "Admin" }
                    
                    );

                    // Seed products
                    context.Products.AddRange(
                        new Product { Name = "lipstick", Price = 10.99M, Description = "Description 1", StockQuantity = 100, DiscountPrice = 2.99M, ImageUrl = "https://imgur.com/nrnix1d" },
                        new Product { Name = "brush", Price = 12.99M, Description = "Description 2", StockQuantity = 150, DiscountPrice = 3.99M, ImageUrl = "https://imgur.com/gW72U4l" },
                        new Product { Name = "brush with a pan", Price = 19.99M, Description = "Description 3", StockQuantity = 20, DiscountPrice = 4.99M, ImageUrl = "https://imgur.com/Ltv8m8Z" }
                    
                    );

                    // Seed categories
                    context.Categories.AddRange(
                        new Category { Name = "eyebrows", Description = "Description 1" },
                        new Category { Name = "eyelashes", Description = "Description 2" },
                        new Category { Name = "lips", Description = "Description 3" }
                    
                    );

                    context.SaveChanges();
                }
            }
        }

    }
}