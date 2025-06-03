using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BookishContext _dbContext;

    public HomeController(ILogger<HomeController> logger, BookishContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext
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

        public IActionResult Data()
    {
        var books = dbContext.Books.Where(book => book.Title = "A thing");
        var viewModel = new BookViewModel { Books = books };
        return View(viewModel);
    }
}
