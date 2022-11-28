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
        public async Task<Response<IReadOnlyCollection<Bookshelf>>> GetAllBookshelves()
        {
            return new(200, "List of all bookshelves", await DbContext.Bookshelves.Include(Bookshelf => Bookshelf.Books).ToListAsync());
        }

        // GET: api/Bookshelf/{id}
        [HttpGet("{id}")]
        public async Task<Response<Bookshelf>> GetBookshelfById(int id)
        {
            if (await DbContext.Bookshelves.FindAsync(id) is Bookshelf bookshelf)
            {
                return new(200, $"Bookshelf of id {id} and name '{bookshelf.ShelfName}'", bookshelf);
            }

            return new(404, $"Bookshelf of id {id} is not found", null);
        }

        // POST: api/Bookshelf
        [HttpPost]
        public async Task<Response<Bookshelf>> CreateBookshelf([FromBody] UpdateOrCreateBookshelfRequest bookshelf_request)
        {
            var new_bookshelf = new Bookshelf { ShelfName = bookshelf_request.ShelfName };
            await DbContext.Bookshelves.AddAsync(new_bookshelf);
            await DbContext.SaveChangesAsync();
            return new(201, $"Bookshelf of name '{bookshelf_request.ShelfName}' has been created", new_bookshelf);
        }

        // PUT: api/Bookshelf/{id}
        [HttpPut("{id}")]
        public async Task<Response<Bookshelf>> UpdateBookshelf(int id, [FromBody] UpdateOrCreateBookshelfRequest bookshelf)
        {
            var bookshelf_to_update = await DbContext.Bookshelves.Include(Bookshelf => Bookshelf.Books).FirstOrDefaultAsync(Bookshelf => Bookshelf.Id == id);

            if (bookshelf_to_update is null)
                return new(404, $"Bookshelf of Id {id} is not found", null);

            bookshelf_to_update.ShelfName = bookshelf.ShelfName;
            await DbContext.SaveChangesAsync();
            return new(200, $"Success! Bookshelf of Id {id} has been updated", bookshelf_to_update);
        }

        // DELETE: api/Bookshelf/{id}
        [HttpDelete("{id}")]
        public async Task<Response<Bookshelf>> DeleteBookshelf(int id)
        {
            var bookshelf_to_delete = await DbContext.Bookshelves.Include(Bookshelf => Bookshelf.Books).FirstOrDefaultAsync(Bookshelf => Bookshelf.Id == id);

            if (bookshelf_to_delete is null)
                return new(404, $"Bookshelf of Id {id} not found", null);

            DbContext.Bookshelves.Remove(bookshelf_to_delete);
            await DbContext.SaveChangesAsync();

            return new(200, $"Bookshelf of Id {id} and name {bookshelf_to_delete.ShelfName} has been deleted", bookshelf_to_delete);
        }
    }
}