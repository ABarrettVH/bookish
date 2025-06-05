namespace bookish.Models;

public class CheckOutViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public List<Book> BooksOut {get; set;}

    public Book book {get; set;}

    public Member member {get; set;}

    public int BookID {get; set;}
    public int MemberID {get; set;}
    public string? Title {get;set;}
    public string? Author {get;set;}

    public string? Message { get; set; }



}