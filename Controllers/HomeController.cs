using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using BookishDB;
// using Book;

namespace bookish.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly BookishDBContext _context;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = new BookishDBContext();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Book()
    {
        var books = _context.Books.ToList();
        return View(new BookViewModel { Book = books });
    }

    public IActionResult Librarian() {
        var books = _context.Books.ToList();

        return View(new LibrarianViewModel { Book = books });
    }

    public IActionResult AddBook(LibrarianViewModel addbooks) {
        using (var context = new BookishDBContext())
        {
  
            Book? book = context.Books.FirstOrDefault(book => book.Title == addbooks.Title && book.Author == addbooks.Author);
            if (book == null && addbooks.Title != null && addbooks.Author !=null) {
                book = new Book() { Title = addbooks.Title, Author = addbooks.Author, Copies = addbooks.NumberCopies, AvailableCopies = addbooks.NumberCopies };
                context.Books.Add(book);

                context.SaveChanges();
                return View();

            }
            else {
                book.Copies += addbooks.NumberCopies;
                book.AvailableCopies += addbooks.NumberCopies;
                context.SaveChanges();
                return View();
            }


        }
    }
}
