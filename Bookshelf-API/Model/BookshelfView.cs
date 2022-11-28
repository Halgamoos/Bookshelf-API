namespace Bookshelf_API.Model
{
	/// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
	/// BookshelfView is mean to encapsulate the specific data that is to be sent to the client.
	public class BookshelfView
	{
		public int Id { get; set; }
		public string ShelfName { get; set; } = string.Empty;
        public ICollection<BookView>? Books { get; set; } = new List<BookView>();
	}
}