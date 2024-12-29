namespace backend.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } 
    
    // Foreign keys
    public int AuthorId { get; set; }
    public int BlogPostId { get; set; }
    
    // Navigation keys
    public User Author { get; set; }
    public Blog BlogPost { get; set; }
}