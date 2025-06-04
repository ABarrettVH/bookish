//using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace BookishDB
{
    public class BookishDBContext : DbContext
    {
        // Put all the tables you want in your database here
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
         public DbSet<BookOut> BookOuts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }
    }
}
