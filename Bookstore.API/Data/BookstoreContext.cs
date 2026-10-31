using Bookstore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Data;

public class BookstoreContext(DbContextOptions<BookstoreContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}
