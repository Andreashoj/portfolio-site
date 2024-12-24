namespace backend.Models;

public class BlogModel
{
    public int Id { get; init; }
    public int PageView { get; set; } = 0;
    public string Slug { get; set; } = string.Empty;
}