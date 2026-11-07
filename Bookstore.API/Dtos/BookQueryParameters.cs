namespace Bookstore.API.Dtos;

public class BookQueryParameters : PaginationParameters
{
    public string? Keyword { get; set; }
    public string? Genres { get; set; }
    public string? Sort { get; set; }
}
