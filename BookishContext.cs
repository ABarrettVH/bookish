using bookish.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishContext : DbContext
    {
        // Put all the tables you want in your database here
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is the configuration used for connecting to the database
            try
            {

                optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
                Console.WriteLine("ACCESSED DATABASE");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR IN CONNECTION");
            }
            ;
        }
    }
}