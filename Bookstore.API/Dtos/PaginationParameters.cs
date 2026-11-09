namespace Bookstore.API.Dtos;

public class PaginationParameters
{
    private const int MaxPageSize = 50;

    private int _pageIndex = 1;
    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < 1 ? _pageIndex : value;
    }

    private int _pageSize = 3;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value switch
        {
            < 1 => _pageSize,
            > MaxPageSize => MaxPageSize,
            _ => value
        };
    }
}
