public class Book
{
    public int BookID { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int Copies { get; set; }
    public int AvailableCopies { get; set; }
}