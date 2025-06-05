namespace bookish.Models;

public class MemberViewModel
{



    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? email { get; set; }

    public List<Member>? Members {get; set;}
    public List<Book>? BooksOut {get; set;}
}