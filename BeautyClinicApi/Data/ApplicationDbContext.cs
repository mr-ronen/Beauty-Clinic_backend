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

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }


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
                        new Product { StockQuantity = 50, Name = "lipstick", Price = 10.99M, Description = "Description 1",  DiscountPrice = 2.99M, ImageUrl = "https://i.imgur.com/nrnix1d.png" },
                        new Product { StockQuantity = 45, Name = "brush", Price = 12.99M, Description = "Description 2",  DiscountPrice = 3.99M, ImageUrl = "https://i.imgur.com/Ltv8m8Z.png" },
                        new Product { StockQuantity = 20, Name = "brush with a pan", Price = 19.99M, Description = "Description 3",  DiscountPrice = 4.99M, ImageUrl = "https://i.imgur.com/gW72U4l.png" },
                        new Product { StockQuantity = 45, Name = "lipstick", Price = 21.99M, Description = "Description 4",  DiscountPrice = 7.99M, ImageUrl = "https://i.imgur.com/nrnix1d.png" },
                        new Product { StockQuantity = 55, Name = "brush", Price = 23.99M, Description = "Description 5",  DiscountPrice = 5.99M, ImageUrl = "https://i.imgur.com/Ltv8m8Z.png" },
                        new Product { StockQuantity = 62, Name = "brush with a pan", Price = 25.99M, Description = "Description 6",  DiscountPrice = 6.99M, ImageUrl = "https://i.imgur.com/gW72U4l.png" },
                        new Product { StockQuantity = 55, Name = "pen", Price = 3.99M, Description = "new gen pen", DiscountPrice = 0.99M, ImageUrl = "https://i.imgur.com/yXKigsum.png" },
                        new Product { StockQuantity = 55, Name = "sharpner", Price = 4.99M, Description = "new gen sharpner", DiscountPrice = 0.99M, ImageUrl = "https://i.imgur.com/MHhuHm5m.png" },
                        new Product { StockQuantity = 55, Name = "cream", Price = 5.99M, Description = "face cream", DiscountPrice = 0.99M, ImageUrl = "https://i.imgur.com/pfeIzqOm.png" },
                        new Product { StockQuantity = 55, Name = "toothpicks", Price = 5.99M, Description = "for tooth", DiscountPrice = 0.99M, ImageUrl = "https://i.imgur.com/z6DpUtUm.png" },
                        new Product { StockQuantity = 55, Name = "brush", Price = 13.99M, Description = "Description 11", DiscountPrice = 0.99M, ImageUrl = "https://i.imgur.com/Ltv8m8Z.png" }

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