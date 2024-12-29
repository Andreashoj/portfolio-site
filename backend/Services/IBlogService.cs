using backend.Models;

namespace backend.Services;

public interface IBlogService
{
    Task<Blog> IncrementLikesAsync(string slug);
    Task<Blog> GetLikesAsync(string slug);
}