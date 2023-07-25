using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ProductOrder_application.Models
{
    public class ProductOrder_applicationContext : DbContext
    {
        public ProductOrder_applicationContext(DbContextOptions<ProductOrder_applicationContext> options) : base(options)
        {
        }

        public DbSet<StaffMemberDetails> StaffMemberDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<StaffMemberDetails>().ToTable("StaffMemberDetails");

            // Configure the 'TotalAmount' property in the 'Order' entity to use 'decimal(18,2)' as the column type.
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            // Configure the 'Price' property in the 'Product' entity to use 'decimal(18,2)' as the column type.
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Configure the 'Quantity' property in the 'OrderItem' entity to use 'int' as the column type.
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Quantity)
                .HasColumnType("int");

                modelBuilder.Entity<OrderItems>() // Add the TotalAmount property configuration for OrderItem
                .Property(oi => oi.TotalAmount)
                .HasColumnType("decimal(18,2)");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5OC6KF6\\SQLEXPRESS;Database=ProductOrder;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
