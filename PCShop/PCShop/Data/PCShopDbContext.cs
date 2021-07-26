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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

           

            base.OnModelCreating(builder);
        }
    }
}
