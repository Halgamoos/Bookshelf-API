namespace Bookshelf_API.Model
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Description { get; set; } = string.Empty;
		public Bookshelf? Bookshelf { get; set; }
    }
}