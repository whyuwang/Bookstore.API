using Bookstore.API.Data;
using Bookstore.API.Dtos;
using Bookstore.API.Entities;
using Bookstore.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(BookstoreContext context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<Book>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResponse<Book>>> GetBooks([FromQuery] BookQueryParameters parameters)
        {
            var query = context.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(parameters.Keyword))
            {
                query = query.Where(b =>
                    b.Title.Contains(parameters.Keyword)
                    || b.Isbn.Contains(parameters.Keyword)
                    || b.Author.Contains(parameters.Keyword));
            }

            if (!string.IsNullOrWhiteSpace(parameters.Genres))
            {
                var genreArray = parameters.Genres.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (genreArray.Length > 0)
                {
                    query = query.Where(b => genreArray.Contains(b.Genre));
                }
            }

            query = (parameters.Sort?.ToLower()) switch
            {
                "title" => query.OrderBy(b => b.Title),
                "title_desc" => query.OrderByDescending(b => b.Title),
                "price" => query.OrderBy(b => b.Price),
                "price_desc" => query.OrderByDescending(b => b.Price),
                "date" => query.OrderBy(b => b.PublishedDate),
                "date_desc" => query.OrderByDescending(b => b.PublishedDate),
                _ => query.OrderBy(b => b.Id),
            };
            var pagedResponse = await query.AsNoTracking().ToPagedResponseAsync(parameters);
            return Ok(pagedResponse);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("genres")]
        [ProducesResponseType(typeof(IReadOnlyList<string>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<string>>> GetGenres()
        {
            var genres = await context.Books.Select(b => b.Genre).Distinct().ToListAsync();
            return Ok(genres);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Book>> CreateBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Isbn = bookDto.Isbn,
                Publisher = bookDto.Publisher,
                Author = bookDto.Author,
                Genre = bookDto.Genre
            };
            context.Entry(book).CurrentValues.SetValues(bookDto);
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            context.Entry(book).CurrentValues.SetValues(bookDto);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
