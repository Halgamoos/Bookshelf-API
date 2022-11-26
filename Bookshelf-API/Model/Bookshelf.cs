namespace Bookshelf_API.Model
{
	public class Bookshelf
	{
		// constructor to add Book objects to the Books list
		public Bookshelf()
		{
			Books = new List<Book>();
		}

		public int ShelfId { get; set; }
		public string ShelfName { get; set; } = string.Empty;
		public List<Book> Books { get; set; }
	}
}