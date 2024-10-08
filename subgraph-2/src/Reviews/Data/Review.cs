using System.ComponentModel.DataAnnotations.Schema;

namespace Reviews.Data;

public sealed class Review
{
    [IsProjected]
    [Column("id")]
    public int Id { get; set; }
    [IsProjected]
    [Column("user_id")]
    public int UserId { get; set; }
    [IsProjected]
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("rating")]
    public required int Rating { get; set; }
    [Column("review")]
    public required string Comment { get; set; }
    [Column("created_at")]
    public required string CreatedAt { get; set; }

   // [UseProjection]
    public Product? Product { get; set; }
}
