using Microsoft.EntityFrameworkCore;
using WebMarket.Models;

namespace WebMarket.DbData
{
    public class MarketDbContext:DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> dbContextOptions):base(dbContextOptions) 
        {
                
        }
        public DbSet<Product> Products { get; set; }
    }
}
