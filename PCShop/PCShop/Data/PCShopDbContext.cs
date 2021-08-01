using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCShop.Data.Models;


namespace PCShop.Data
{
    public class PCShopDbContext : IdentityDbContext
    {


        public PCShopDbContext(DbContextOptions<PCShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Product> Products { get; init; }

        public DbSet<Cart> Carts { get; init; }

        public DbSet<Cart_item> CartItems { get; init; }

        public DbSet<Order> Orders { get; init; }

        public DbSet<Order_item> Orderitems { get; init; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //Cart

            builder
                .Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            builder
                .Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne(c => c.Cart)
                .HasForeignKey(c => c.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Cart_item>()
                .HasKey(ci => new { ci.Id, ci.CartId });


            builder
                 .Entity<Cart_item>()
                 .HasOne(c => c.Product)
                 .WithMany(c => c.Cart_Item)
                 .HasForeignKey(c => c.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);

            //Order

            builder
               .Entity<Order>()
               .HasOne(c => c.User)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.UserId);

            builder
                .Entity<Order>()
                .HasMany(c => c.Items)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Order_item>()
                .HasKey(ci => new { ci.Id, ci.OrderId });


            builder
                 .Entity<Order_item>()
                 .HasOne(c => c.Product)
                 .WithMany(c => c.Order_Item)
                 .HasForeignKey(c => c.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(builder);
        }
    }
}
