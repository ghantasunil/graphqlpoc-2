using Microsoft.EntityFrameworkCore;

namespace Reviews.Data;

public class ReviewDbContext : DbContext
{
    public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
        : base(options) { }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Product> Products { get; set; }
}