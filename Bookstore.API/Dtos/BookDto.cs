using System.ComponentModel.DataAnnotations;

namespace Bookstore.API.Dtos;

public class BookDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Isbn { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }

    [Required]
    public string Publisher { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    public string? Description { get; set; }

    [Required]
    public string Genre { get; set; } = string.Empty;
}
