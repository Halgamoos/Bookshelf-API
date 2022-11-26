using Bookshelf_API.Model;
using Microsoft.AspNetCore.Mvc;


namespace Bookshelf_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookshelfController : ControllerBase
    {
        private static List<Bookshelf> bookshelves = new List<Bookshelf>
        {
            new Bookshelf
            {
                ShelfId = 1,
                ShelfName = "Fiction",
                Books = new List<Book>
                {
                    new Book
                    {
                        BookId = 1,
                        Title = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Pages = 295,
                        Description = "A hobbit is a small, furry creature that lives in a hole in the ground."
                    },
                    new Book
                    {
                        BookId = 2,
                        Title = "The Lord of the Rings",
                        Author = "J.R.R. Tolkien",
                        Pages = 1216,
                        Description = "A ring is a magical object that can be used to control people."
                    },
                    new Book
                    {
                        BookId = 3,
                        Title = "The Silmarillion",
                        Author = "J.R.R. Tolkien",
                        Pages = 432,
                        Description = "The Silmarillion is a collection of stories about the creation of Middle Earth."
                    }
                }
            }
        };

        // GET: api/Bookshelf
        [HttpGet]
        public ActionResult<List<Bookshelf>> GetAllBookShelves()
        {
            return Ok(bookshelves);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bookshelf>> GetBookShelf(int id)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            return Ok(bookshelf);
        }

        [HttpPost]
        public async Task<ActionResult<List<Bookshelf>>> AddBookshelf(Bookshelf bookshelf)
        {
            bookshelves.Add(bookshelf);
            return Ok(bookshelves);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Bookshelf>>> UpdateBookshelf(int id, Bookshelf bookshelf)
        {
            var bookshelfToUpdate = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelfToUpdate == null)
            {
                return NotFound("Book shelf not found");
            }

            bookshelfToUpdate.ShelfName = bookshelf.ShelfName;
            return Ok(bookshelves);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Bookshelf>>> DeleteBookshelf(int id)
        {
            var bookshelfToDelete = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelfToDelete == null)
            {
                return NotFound("Book shelf not found");
            }

            bookshelves.Remove(bookshelfToDelete);
            return Ok(bookshelves);
        }

        [HttpGet("{id}/books")]
        public async Task<ActionResult<List<Book>>> GetAllBooksFromBookshelf(int id)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            if (bookshelf.Books == null)
            {
                return Ok("There are no books in this bookshelf!");
            }

            return Ok(bookshelf.Books);
        }

        [HttpGet("{id}/books/{bookId}")]
        public async Task<ActionResult<Book>> GetBookFromBookshelf(int id, int bookId)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            if (bookshelf.Books == null)
            {
                return NotFound("There are no books in this bookshelf!");
            }

            var book = bookshelf.Books.Find(b => b.BookId == bookId);

            if (book == null)
            {
                return NotFound("Book not found in this bookshelf!");
            }

            return Ok(book);
        }

        [HttpPost("{id}/books")]
        public async Task<ActionResult<List<Book>>> AddBookToBookshelf(int id, Book book)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            if (bookshelf.Books == null)
            {
                bookshelf.Books = new List<Book>();
            }

            bookshelf.Books.Add(book);
            return Ok(bookshelf.Books);
        }

        [HttpPut("{id}/books/{bookId}")]
        public async Task<ActionResult<List<Book>>> UpdateBookInBookshelf(int id, int bookId, Book book)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            if (bookshelf.Books == null)
            {
                return NotFound("There are no books in this bookshelf!");
            }

            var bookToUpdate = bookshelf.Books.Find(b => b.BookId == bookId);

            if (bookToUpdate == null)
            {
                return NotFound("Book not found in this bookshelf!");
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Description = book.Description;
            return Ok(bookshelf.Books);
        }

        [HttpDelete("{id}/books/{bookId}")]
        public async Task<ActionResult<List<Book>>> DeleteBookFromBookshelf(int id, int bookId)
        {
            var bookshelf = bookshelves.Find(b => b.ShelfId == id);

            if (bookshelf == null)
            {
                return NotFound("Book shelf not found");
            }

            if (bookshelf.Books == null)
            {
                return NotFound("There are no books in this bookshelf!");
            }

            var bookToDelete = bookshelf.Books.Find(b => b.BookId == bookId);

            if (bookToDelete == null)
            {
                return NotFound("Book not found in this bookshelf!");
            }

            bookshelf.Books.Remove(bookToDelete);
            return Ok(bookshelf.Books);
        }
    }
}