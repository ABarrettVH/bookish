namespace bookish.Models;
using Microsoft.EntityFrameworkCore;

public class DataViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
   // public DbSet<Book> Books { get; set; }

    public Book NewBook = new Book("Harry Potter", "Rowling");

/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }
        */
}
