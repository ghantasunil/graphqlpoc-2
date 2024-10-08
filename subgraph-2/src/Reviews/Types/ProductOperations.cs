using HotChocolate.Fusion.SourceSchema.Types;

using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

public static partial class ProductOperations
{
    [Lookup]
    [Query]
    //[UseProjection]
    [UseFirstOrDefault]
    public static IQueryable<Product> GetProduct(
        int id,
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return dbContext.Products
            .Include(p => p.Reviews)
            .AsNoTracking()
            .Where(t => t.Id == id);
    }

    [Query]
    [UsePaging]
    //[UseProjection]
    [UseSorting]
    public static IQueryable<Product> GetProducts(
        ReviewDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return dbContext.Products
            .Include(p => p.Reviews)
            .OrderBy(product => product.Id)
            .AsNoTracking();
    }
}