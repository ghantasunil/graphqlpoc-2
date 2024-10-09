using System.ComponentModel.DataAnnotations.Schema;

namespace Reviews.Data;

public sealed class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("price")]
    public required int Price { get; set; }
    [Column("created_at")]
    public required string CreatedAt { get; set; }

    public List<Review>? Reviews { get; set; }

}