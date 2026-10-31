using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Entities;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Isbn { get; set; }
    public DateTime PublishedDate { get; set; }
    public required string Publisher { get; set; }
    public required string Author { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    public string? CoverImageUrl { get; set; }
    public required string Genre { get; set; }
}