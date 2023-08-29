using System.Xml;
using Microsoft.EntityFrameworkCore;
namespace bookApp.Models
{
	public class AppDbContext : DbContext
	{
        public DbSet<Book> Book { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
    }


    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public Uri? CoverImage { get; set; }
        public int? Rating { get; set; }
    }
}

