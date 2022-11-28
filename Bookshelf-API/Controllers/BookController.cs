using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Bookshelf_API.Model;

namespace Bookshelf_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookshelfDataContext DbContext;
        
        public BookController(BookshelfDataContext db_context) 
            => DbContext = db_context;

        // GET: api/Book
        [HttpGet]
        public async Task<Response<IReadOnlyCollection<BookView>>> GetAllBooks()
        {
            var Books = await DbContext.Books.Include(Book => Book.Bookshelf).Select(
                Book => new BookView
                {
                    Id = Book.Id,
                    BookshelfName = Book.Bookshelf.ShelfName,
                    Title = Book.Title,
                    Author = Book.Author,
                    Pages = Book.Pages,
                    Description = Book.Description
                }
            ).ToListAsync();

            return new(200, "List of all books", Books);
        }

        // POST: api/Book
        [HttpPost]
        public async Task<Response<BookView>> AddBookToBookshelf([FromBody] UpdateOrCreateBookRequest book_request)
        {
            var bookshelf = await DbContext.Bookshelves.FindAsync(book_request.BookshelfId);

            if (bookshelf is null)
            {
                return new(404, $"Bookshelf of id {book_request.BookshelfId} is not found", null);
            }

            var new_book = new Book
            {
                Title = book_request.Title,
                Author = book_request.Author,
                Pages = book_request.Pages,
                Description = book_request.Description,
                Bookshelf = bookshelf
            };

            await DbContext.Books.AddAsync(new_book);
            await DbContext.SaveChangesAsync();

            var bookView = new BookView
            {
                BookshelfName = new_book.Bookshelf.ShelfName,
                Id = new_book.Id,
                Title = new_book.Title,
                Author = new_book.Author,
                Pages = new_book.Pages,
                Description = new_book.Description
            };

            return new(201, $"Book of id {new_book.Id} and title '{new_book.Title}' is created in Bookshelf named {bookView.BookshelfName}", bookView);
        }
    }
}