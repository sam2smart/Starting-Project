
using AppCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppCommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
