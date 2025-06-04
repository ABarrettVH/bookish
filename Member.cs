using System.ComponentModel.DataAnnotations.Schema;

public class Member
{
    public int MemberID { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public string? email { get; set; }
}
