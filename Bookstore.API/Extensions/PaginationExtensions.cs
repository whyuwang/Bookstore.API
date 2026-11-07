using Bookstore.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Extensions;

public static class PaginationExtensions
{
    public static async Task<PagedResponse<T>> ToPagedResponseAsync<T>(this IQueryable<T> source, PaginationParameters parameters)
    {
        int count = await source.CountAsync();
        var items = await source
            .Skip((parameters.PageIndex - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        return new PagedResponse<T>(parameters.PageIndex, parameters.PageSize, count, items);
    }
}
