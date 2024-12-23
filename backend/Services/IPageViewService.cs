using backend.Models;

namespace backend.Services;

public interface IPageViewService
{
    Task<BlogModel> GetAsync(string slug);
    Task<List<BlogModel>> GetBatchAsync(string[] slug);
}   
