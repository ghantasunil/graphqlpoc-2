using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

public static partial class ProductOperations
{
    [Query]
    public static async Task<Product?> GetProductAsync(
        int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync<Product>();
    }

    [Query]
    [UsePaging]
    [UseProjection]
    public static IQueryable<Product> GetProducts(
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return dbContext.Products
            .AsNoTracking()
            .OrderBy(r => r.Id);
    }
}