using Iticket.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iticket.Data.Context;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductEvent> ProductEvents { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Wishlist> Wishlist { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasIndex(p => new { p.Name, p.Slug, p.Ordering })
            .IsUnique();

        base.OnModelCreating(builder);
    }
}
