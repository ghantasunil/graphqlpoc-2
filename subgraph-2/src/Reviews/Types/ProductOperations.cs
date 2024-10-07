using HotChocolate.Fusion.SourceSchema.Types;

using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

public static partial class ProductOperations
{
    [Lookup]
    [Query]
    public static async Task<Product?> GetProductAsync(
        int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
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