
namespace Bookshelf_API.Model
{
    public record UpdateOrCreateBookshelfRequest(string ShelfName);

    public record UpdateOrCreateBookRequest(string Title, string Author, int Pages, string Description);
}