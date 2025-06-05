using System.ComponentModel.DataAnnotations.Schema;

public class BookOut
{
    public int BookOutID { get; set; }

    // Foreign key property
    public int MemberID { get; set; }

    // Navigation property
    public Member? Member { get; set; }

    public int BookID { get; set; }
    public Book? Book { get; set; }

    public DateOnly DueDate { get; set;}
}