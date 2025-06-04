namespace bookish.Models;

public class AddBookViewModel
{

    public List<Book>? Book { get; set; }

    public Book? ABook { get; set; }


    public string? Title { get; set; }
    public string? Author { get; set; }
    public int NumberCopies { get; set; }
    
    public string? Message { get; set; }
}