using backend.Models;

namespace backend.Services;

public interface IPageViewService
{
    Task<List<BlogModel>> GetBatchAsync(string[] slug);
    Task<BlogModel> IncrementAsync(string slug);
}   
