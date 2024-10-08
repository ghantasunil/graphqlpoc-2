using Microsoft.EntityFrameworkCore;

namespace Reviews.Data;

public class ReviewDbContext : DbContext
{
    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(product => product.Reviews)
            .WithOne(review => review.Product)
            .IsRequired();
    }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Product> Products { get; set; }
}