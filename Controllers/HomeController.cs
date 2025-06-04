using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using BookishDB;

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

    public IActionResult Book(){
        var books = _context.Books.ToList();
        return View(new BookViewModel { Book = books });
    }
    // public IActionResult Book(){
    //     var books = _context.Books.ToList();
    //     return View(new BookViewModel { Book = books });
    // }
}
