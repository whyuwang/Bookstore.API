using Bookstore.API.Entities;

namespace Bookstore.API.Data;

public class DbInitializer
{
    public static void Initialize(BookstoreContext context)
    {
        if (context.Books.Any())
        {
            return;
        }

        context.Books.AddRange(
            new Book
            {
                Title = "The Great Gatsby",
                Isbn = "9780743273565",
                PublishedDate = new DateTime(1925, 4, 10),
                Publisher = "Scribner",
                Author = "F. Scott Fitzgerald",
                Price = 12.99m,
                Stock = 18,
                Description = "A novel set in the Jazz Age, following Jay Gatsby and the people around him.",
                Genre = "Fiction"
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                Isbn = "9780061120084",
                PublishedDate = new DateTime(1960, 7, 11),
                Publisher = "J. B. Lippincott & Co.",
                Author = "Harper Lee",
                Price = 14.99m,
                Stock = 12,
                Description = "A coming-of-age story about justice and compassion in a small Southern town.",
                Genre = "Fiction"
            },
            new Book
            {
                Title = "1984",
                Isbn = "9780451524935",
                PublishedDate = new DateTime(1949, 6, 8),
                Publisher = "Secker & Warburg",
                Author = "George Orwell",
                Price = 10.99m,
                Stock = 25,
                Description = "A dystopian novel about surveillance, censorship, and totalitarian power.",
                Genre = "Science Fiction"
            },
            new Book
            {
                Title = "Pride and Prejudice",
                Isbn = "9780141439518",
                PublishedDate = new DateTime(1813, 1, 28),
                Publisher = "T. Egerton",
                Author = "Jane Austen",
                Price = 9.99m,
                Stock = 20,
                Description = "A classic novel of manners, family, and marriage in Regency England.",
                Genre = "Romance"
            },
            new Book
            {
                Title = "The Hobbit",
                Isbn = "9780547928227",
                PublishedDate = new DateTime(1937, 9, 21),
                Publisher = "George Allen & Unwin",
                Author = "J. R. R. Tolkien",
                Price = 15.99m,
                Stock = 10,
                Description = "Bilbo Baggins joins a company of dwarves on a quest to reclaim their home.",
                Genre = "Fantasy"
            }
        );

        context.SaveChanges();
    }
}
