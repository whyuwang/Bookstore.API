namespace Bookstore.API.Dtos;

public class PagedResponse<T>(int pageIndex, int pageSize, int totalCount, IReadOnlyList<T> items)
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public int TotalCount { get; set; } = totalCount;
    public IReadOnlyList<T> Items { get; set; } = items;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
