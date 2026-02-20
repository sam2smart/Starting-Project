using Ecommerces.Entities;
using Microsoft.EntityFrameworkCore;
//using EcommerceApp.Entities;

namespace Ecommerces.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<AppUser> Users => Set<AppUser>();
    }
}
