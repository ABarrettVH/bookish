public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }

    public Book (string title, string author){
        this.Title = title;
        this.Author = author;
    }

}