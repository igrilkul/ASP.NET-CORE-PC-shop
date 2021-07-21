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

        public DbSet<Case> Cases { get; init; }

        public DbSet<CPU> CPUs { get; init; }

        public DbSet<CPUCooler> CPUCoolers { get; init; }

        public DbSet<GPU> GPUs { get; init; }

        public DbSet<Motherboard> Motherboards { get; init; }

        public DbSet<PSU> PSUs { get; init; }

        public DbSet<RAM> RAMs { get; init; }
    }
}
