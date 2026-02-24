using SimpleEcommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SimpleEcommerce.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tables
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Carts { get; set; }
        public DbSet<Carts> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CartItem relationships
            modelBuilder.Entity<Carts>()
                .HasOne(c => c.Product)
                .WithMany() // You can add a Products->CartItems navigation later if needed
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Carts>()
                .HasOne<Users>()
                .WithMany() // You can add User->CartItems navigation later if needed
                .HasForeignKey(c => c.UserId);
        }
    }
}
