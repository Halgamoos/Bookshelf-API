namespace Bookshelf_API.Model
{
	public class Bookshelf
	{
		public int Id { get; set; }
		public string ShelfName { get; set; } = string.Empty;
		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}