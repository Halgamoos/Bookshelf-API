using Microsoft.EntityFrameworkCore;

namespace Bookshelf_API.Model
{
	public class BookshelfDataContext : DbContext
	{
		private readonly IConfiguration _config;
		public DbSet<Bookshelf> Bookshelves => Set<Bookshelf>();
		public DbSet<Book> Books => Set<Book>();

		public BookshelfDataContext(IConfiguration config, DbContextOptions<BookshelfDataContext> options) : base(options) 
			=> _config = config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
			=> optionsBuilder.UseMySql(
				connectionString: _config.GetConnectionString("BookshelfDB"),
				serverVersion: ServerVersion.AutoDetect(_config.GetConnectionString("BookshelfDB"))
			);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bookshelf>()
				.HasKey(Bookshelf => Bookshelf.Id);
			
			modelBuilder.Entity<Bookshelf>()
				.HasMany(Bookshelf => Bookshelf.Books)
				.WithOne(Book => Book.Bookshelf);
			
			modelBuilder.Entity<Book>()
				.HasKey(Book => Book.Id);

			modelBuilder.Entity<Book>()
				.HasOne(Book => Book.Bookshelf)
				.WithMany(Bookshelf => Bookshelf.Books);
		}
	}
}

