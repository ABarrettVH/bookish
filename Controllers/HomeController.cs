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

    public HomeController(ILogger<HomeController> logger, BookishDBContext context)
    {
        _logger = logger;
        _context = context;
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

    public IActionResult Book(string searchString)
    {
        List<Book> books; //_context.Books.ToList();

        if (!String.IsNullOrEmpty(searchString))
        {
            books = _context.Books.Where(b => b.Author.Contains(searchString)
                                   || b.Title.Contains(searchString)).ToList();


            books = books.OrderBy(b => b.Author).ToList();
            return View(new BookViewModel { Book = books });
        }
        else
        {
            books = _context.Books.ToList();
            return View(new BookViewModel { Book = books });
        }
    }

    public IActionResult AddBook(BookViewModel addbooks)
    {
        addbooks.Message = null;

        Book? book = _context.Books.FirstOrDefault(book => book.Title == addbooks.Title && book.Author == addbooks.Author);
        if (book == null && addbooks.Title != null && addbooks.Author != null)
        {
            book = new Book() { Title = addbooks.Title, Author = addbooks.Author, Copies = addbooks.NumberCopies, AvailableCopies = addbooks.NumberCopies };
            _context.Books.Add(book);

            _context.SaveChanges();
            addbooks.Message = "New book added";
        }
        else
        {
            if (book != null)
            {
                book.Copies += addbooks.NumberCopies;
                book.AvailableCopies += addbooks.NumberCopies;
                _context.SaveChanges();
                addbooks.Message = "Copy number updated";
            }
        }


        return View(addbooks);
    }

    public IActionResult RemoveBook(BookViewModel addbooks)
    {
        addbooks.Message = null;

        Book? book = _context.Books.FirstOrDefault(book => book.Title == addbooks.Title && book.Author == addbooks.Author);
        if (book == null && addbooks.Title != null)
        {
            addbooks.Message = "Book doesn't exist";
        }
        else
        {

            if (book != null && addbooks.Title != null && addbooks.Author != null)
            {
                addbooks.Message = $"Copy number reduced: {book.Copies} books left";

                book.Copies -= addbooks.NumberCopies;
                book.AvailableCopies -= addbooks.NumberCopies;
                if (book.Copies <= 0)
                {
                    _context.Books.Remove(book);
                    addbooks.Message = "Book deleted from catalogue";
                }
                _context.SaveChanges();
            }
        }

        return View(addbooks);
    }
    
        public IActionResult Member(string searchString)
    {
        List<Member> members; 

        
        if (!String.IsNullOrEmpty(searchString))
        {
            members = _context.Members.Where(m => m.Name.Contains(searchString)
                                   || m.email.Contains(searchString)).ToList();

            
            members = members.OrderBy(m => m.Name).ToList();
            return View(new MemberViewModel { Members = members });
        }
        else {
            members = _context.Members.ToList();
    return View(new MemberViewModel { Members = members });
        }
    }


        public IActionResult CheckOut(CheckOutViewModel checkoutbooks)
    {

        checkoutbooks.Message = null;
        Book book =null;
        Member member =null;


        if (checkoutbooks.BookID !=null) {
            book = _context.Books.FirstOrDefault(book => book.BookID == checkoutbooks.BookID);
        }
        else if (checkoutbooks.Title !=null && checkoutbooks.Author != null) {
            book = _context.Books.FirstOrDefault(book => book.Title == checkoutbooks.Title && book.Author == checkoutbooks.Author);
        }
        else {
            checkoutbooks.Message = "Enter either a book ID or title and author";
        }
        
        if (checkoutbooks.MemberID != null) {
            member = _context.Members.FirstOrDefault(member => member.MemberID == checkoutbooks.MemberID);
        }
        else {
            checkoutbooks.Message = "Please give a member ID number";
        }

        if (book != null && member != null){
        BookOut bookOut = null;
        if (book != null && member != null){
            if (book.AvailableCopies <= 0) {
                checkoutbooks.Message = "No copies available";
                return View(checkoutbooks);
            }
            else{
            bookOut = new BookOut() { BookID = book.BookID,
                                        MemberID = member.MemberID, 
                                        DueDate =  DateOnly.FromDateTime(DateTime.Now).AddDays(30)
                                      };
            _context.BookOuts.Add(bookOut);
            book.AvailableCopies -= 1;
            _context.SaveChanges();
            checkoutbooks.Message = "Book sucessfully checked out";


            }
        }
    }
    else {
        if (book == null ) {
            checkoutbooks.Message = "This book doesn't exist";
        }
         if (member == null) {
            checkoutbooks.Message = "This is not a valid member ID";
        }
    }

        return View(checkoutbooks);
    }

    

}
