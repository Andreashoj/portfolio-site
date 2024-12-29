namespace backend.Models;

public class User
{
    public int Id { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    
    public ICollection<Comment> Comments { get; set; }
}