using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;

namespace Repositories
{
    public class AppDbContext : IdentityDbContext<Account, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderCartItem> OrderCartItems { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public DbSet<StoreLocation> StoreLocations { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<FeedBack> FeedBacks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account entity configuration
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(x => x.FirstName).HasMaxLength(50);
                entity.Property(x => x.LastName).HasMaxLength(50);
                entity.Property(x => x.PhoneNumber).HasMaxLength(15);
                entity.Property(x => x.VerificationCode).HasMaxLength(6);
            });

            // Role entity configuration
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(x => x.Description).HasMaxLength(256);
            });

            // Product entity configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
                entity.Property(x => x.BriefDescription).HasMaxLength(256);
                entity.Property(x => x.FullDescription).HasMaxLength(1000);
                entity.Property(x => x.Price).HasColumnType("decimal(18,2)");

                entity.HasMany(x => x.CartItems)
                      .WithOne(ci => ci.Product)
                      .HasForeignKey(ci => ci.ProductID)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_CartItems_Products_ProductID");
            });

            // Category entity configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
            });

            // Cart entity configuration
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(x => x.TotalPrice)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(x => x.Account)
                      .WithMany(a => a.Cart)
                      .HasForeignKey(x => x.AccountID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // CartItem entity configuration
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(ci => ci.Id);

                entity.HasOne(ci => ci.Cart)
                      .WithMany(c => c.CartItems)
                      .HasForeignKey(ci => ci.CartID)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ci => ci.Product)
                      .WithMany(p => p.CartItems)
                      .HasForeignKey(ci => ci.ProductID)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_CartItems_Products_ProductID");
            });
            // OrderCartItem
            modelBuilder.Entity<OrderCartItem>(entity =>
            {
                entity.HasKey(oci => oci.Id);
                entity.HasOne(oci => oci.Order)
                      .WithMany(oc => oc.OrderCartItems)
                      .HasForeignKey(oci => oci.OrderID);
                entity.HasOne(ci => ci.Product)
                      .WithMany(p => p.OrderCartItems)
                      .HasForeignKey(ci => ci.ProductID);
            });
            // Order entity configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);


                entity.HasOne(o => o.Account)
                      .WithMany(a => a.Orders)
                      .HasForeignKey(o => o.AccountID);
            });
          

            // Payment entity configuration
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(x => x.Amount).HasColumnType("decimal(18,2)");

                entity.HasOne(x => x.Order)
                      .WithOne(o => o.Payment)
                      .HasForeignKey<Payment>(x => x.OrderID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Notification entity configuration
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(x => x.Message).IsRequired().HasMaxLength(256);

                entity.HasOne(x => x.Account)
                      .WithMany(a => a.Notifications)
                      .HasForeignKey(x => x.AccountID);
            });

            // ChatMessage entity configuration
            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.Property(x => x.Message).IsRequired().HasMaxLength(500);

                entity.HasOne(x => x.Account)
                      .WithMany(a => a.ChatMessages)
                      .HasForeignKey(x => x.AccountID);
            });

            // StoreLocation entity configuration
            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.Property(x => x.Address).IsRequired().HasMaxLength(256);
                entity.Property(x => x.Latitude).HasPrecision(9, 6);
                entity.Property(x => x.Longitude).HasPrecision(9, 6);
            });
        }
    }
}
