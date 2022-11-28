namespace Bookshelf_API.Model
{
	/// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
	/// BookView is mean to encapsulate the specific data that is to be sent to the client.
	public class BookView
	{
		public int Id { get; set; }
        public string BookshelfName { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}