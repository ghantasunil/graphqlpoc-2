namespace Users.Types;

public record User(int Id);
//public class User
//{
//    public User(int id)
//    {
//        Id = id;
//    }

//    public int Id { get; set; }

//    //public async Task<IReadOnlyCollection<Review>> Reviews(ReviewDbContext context)
//    //{
//    //    return await context.Reviews
//    //        .Include(r => r.Product)
//    //        .AsNoTracking()
//    //        .Where(r => r.UserId == Id)
//    //        .OrderBy(r => r.Id)
//    //        .ToListAsync();
//    //}
//}