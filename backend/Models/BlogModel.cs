namespace backend.Models;

public class Blog
{
    public int Id { get; init; }
    public int PageView { get; set; } = 0;
    public string Slug { get; set; } = string.Empty;
    public int Likes { get; set; }
    public ICollection<Comment> Comments { get; set; }
}