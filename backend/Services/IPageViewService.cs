using backend.Models;

namespace backend.Services;

public interface IPageViewService
{
    Task<List<Blog>> GetBatchAsync(string[] slug);
    Task<Blog> IncrementAsync(string slug);
}   
