using Microsoft.EntityFrameworkCore;

using Reviews.Data;

namespace Users.Types;

[ObjectType<Review>]
public static partial class ReviewExtensions
{
    public static User GetUser([Parent] Review review)
    {
        return new User(review.UserId);
    }
}

public class User
{
    public User(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    public async Task<IReadOnlyCollection<Review>> Reviews(ReviewDbContext context)
    {
        return await context.Reviews
            .AsNoTracking()
            .Where(r => r.UserId == Id)
            .OrderBy(r => r.Id)
            .ToListAsync();
    }
}