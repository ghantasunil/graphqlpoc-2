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

    //[Query]
    //[UsePaging]
    ////[UseProjection]
    //[UseSorting]
    //public static async Task<Product?> GetProducts( // Changed return type to Product?
    //    ReviewDbContext dbContext,
    //    [IsSelected("reviews")] bool includeReviews = false,
    //    CancellationToken cancellationToken = default)
    //{
    //    var query = dbContext.Products.AsNoTracking();

    //    if (includeReviews)
    //    {
    //        query = query.Include(p => p.Reviews);
    //    }

    //    return await query.OrderBy(product => product.Id)
    //        .FirstOrDefaultAsync(cancellationToken);
    //}
}
