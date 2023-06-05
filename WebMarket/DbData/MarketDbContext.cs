using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DbData
{
    public class MarketDbContext : IdentityDbContext<IdentityUser>
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
