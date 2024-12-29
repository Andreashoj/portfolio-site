using backend.data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class BlogService (AppDbContext dbContext) : IBlogService
{
    public async Task<Blog> IncrementLikesAsync(string slug)
    {
        var blog = await dbContext.Blogs.FirstOrDefaultAsync(b => b.Slug == slug);

        if (blog is null)
            throw new ArgumentNullException("Cant find blog with matching ID: ${id}");

        blog.Likes++;

        await dbContext.SaveChangesAsync();

        return blog;
    }
    
    public async Task<Blog> GetLikesAsync(string slug)
    {
        var blog = await dbContext.Blogs.FirstOrDefaultAsync(b => b.Slug == slug);

        if (blog is null)
            throw new ArgumentNullException("Cant find blog with matching ID: ${id}");

        return blog;
    }
}