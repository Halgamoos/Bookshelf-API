using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Bookshelf_API.Model;

namespace Bookshelf_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookshelfController : ControllerBase
    {
        private readonly BookshelfDataContext DbContext;

        public BookshelfController(BookshelfDataContext db_context) 
            => DbContext = db_context;

        // GET: api/Bookshelf
        [HttpGet]
        public async Task<Response<IReadOnlyCollection<BookshelfView>>> GetAllBookshelves()
        {
            return new(200, "List of all bookshelves", await DbContext.Bookshelves.Include(Bookshelf => Bookshelf.Books).Select(
                    Bookshelf => new BookshelfView
                    {
                        Id = Bookshelf.Id,
                        ShelfName = Bookshelf.ShelfName,
                        Books = Bookshelf.Books.Select(
                            Book => new BookView
                            {
                                Id = Book.Id,
                                Title = Book.Title,
                                Author = Book.Author,
                                Pages = Book.Pages,
                                Description = Book.Description,
                                BookshelfName = Bookshelf.ShelfName
                            }
                        ).ToList()
                    }
                ).ToListAsync());
        }

        // GET: api/Bookshelf/{id}
        [HttpGet("{id}")]
        public async Task<Response<BookshelfView>> GetBookshelfById(int id)
        {
            var bookshelf = await DbContext.Bookshelves.FindAsync(id);

            if (bookshelf is null)
            {
                return new(404, $"Bookshelf of id {id} is not found", null);
            }

            var bookshelfView = new BookshelfView
            {
                Id = bookshelf.Id,
                ShelfName = bookshelf.ShelfName,
                Books = bookshelf.Books.Select(
                    Book => new BookView
                    {
                        Id = Book.Id,
                        Title = Book.Title,
                        Author = Book.Author,
                        Pages = Book.Pages,
                        Description = Book.Description,
                        BookshelfName = bookshelf.ShelfName
                    }
                ).ToList()
            };

            return new(200, $"Bookshelf of id {id} and name '{bookshelf.ShelfName}'", bookshelfView);
        }

        // POST: api/Bookshelf
        [HttpPost]
        public async Task<Response<BookshelfView>> CreateBookshelf([FromBody] UpdateOrCreateBookshelfRequest bookshelf_request)
        {
            var bookshelf = new Bookshelf
            {
                ShelfName = bookshelf_request.ShelfName
            };

            await DbContext.Bookshelves.AddAsync(bookshelf);
            await DbContext.SaveChangesAsync();

            var bookshelfView = new BookshelfView
            {
                Id = bookshelf.Id,
                ShelfName = bookshelf.ShelfName,
            };

            return new(201, $"Bookshelf of id {bookshelfView.Id} and name '{bookshelfView.ShelfName}' is created", bookshelfView);
        }

        // PUT: api/Bookshelf/{id}
        [HttpPut("{id}")]
        public async Task<Response<BookshelfView>> UpdateBookshelf(int id, [FromBody] UpdateOrCreateBookshelfRequest bookshelf)
        {
            var bookshelfToUpdate = await DbContext.Bookshelves.FindAsync(id);

            if (bookshelfToUpdate is null)
            {
                return new(404, $"Bookshelf of id {id} is not found", null);
            }

            bookshelfToUpdate.ShelfName = bookshelf.ShelfName;

            await DbContext.SaveChangesAsync();

            var bookshelfView = new BookshelfView
            {
                Id = bookshelfToUpdate.Id,
                ShelfName = bookshelfToUpdate.ShelfName,
                Books = bookshelfToUpdate.Books.Select(
                    Book => new BookView
                    {
                        Id = Book.Id,
                        Title = Book.Title,
                        Author = Book.Author,
                        Pages = Book.Pages,
                        Description = Book.Description,
                        BookshelfName = bookshelfToUpdate.ShelfName
                    }
                ).ToList()
            };

            return new(200, $"Bookshelf of id {bookshelfView.Id} and name '{bookshelfView.ShelfName}' has been updated", bookshelfView);
        }

        // DELETE: api/Bookshelf/{id}
        [HttpDelete("{id}")]
        public async Task<Response<BookshelfView>> DeleteBookshelf(int id)
        {
            var bookshelf = await DbContext.Bookshelves.FindAsync(id);

            if (bookshelf is null)
            {
                return new(404, $"Bookshelf of id {id} is not found", null);
            }

            DbContext.Bookshelves.Remove(bookshelf);
            await DbContext.SaveChangesAsync();

            var bookshelfView = new BookshelfView
            {
                Id = bookshelf.Id,
                ShelfName = bookshelf.ShelfName,
                Books = bookshelf.Books.Select(
                    Book => new BookView
                    {
                        Id = Book.Id,
                        Title = Book.Title,
                        Author = Book.Author,
                        Pages = Book.Pages,
                        Description = Book.Description,
                        BookshelfName = bookshelf.ShelfName
                    }
                ).ToList()
            };

            return new(200, $"Bookshelf of id {bookshelfView.Id} and name '{bookshelfView.ShelfName}' is deleted", bookshelfView);
        }
    }
}