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

        // DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<OrderDetailProduct> OrderDetailProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .Property(u => u.ProfilePhoto)
                .IsRequired(false); // This makes the column nullable

            //primary key for CategoryProduct
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            // Configure the foreign key for CategoryProduct
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId);

            // primary key for OrderDetailProduct is also  join table.
            modelBuilder.Entity<OrderDetailProduct>()
                .HasKey(odp => new { odp.OrderDetailId, odp.ProductId });

            modelBuilder.Entity<OrderDetailProduct>()
            .HasOne(odp => odp.Product)
            .WithMany()
            .HasForeignKey(odp => odp.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId)
            .OnDelete(DeleteBehavior.Restrict);





        }
    }

}