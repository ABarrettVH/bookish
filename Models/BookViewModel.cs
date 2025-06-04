namespace bookish.Models;

public class BookViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public List<Book>? Book { get; set; }

    public string? searchString { get; set; }



}