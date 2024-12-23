using backend.data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class PageViewService (AppDbContext context) : IPageViewService
{
    public async Task<BlogModel> GetAsync(string slug)
    {
        var result = await context.Blogs.FirstOrDefaultAsync(b => b.Slug == slug);

        if (result is null)
        {
            var blogPost = new BlogModel
            {
                Slug = slug,
                PageView = 1
            };

            context.Blogs.Add(blogPost);
            await context.SaveChangesAsync();

            return blogPost;
        }
        
        return result;
    }

    public async Task<List<BlogModel>> GetBatchAsync(string[] slugs)
    {
        var existingBlogs = await context.Blogs.Where(b => slugs.Contains(b.Slug)).ToListAsync();
        var existingSlugs = existingBlogs.Select(b => b.Slug).ToHashSet();
        var missingSlugs = slugs.Where(slug => !existingSlugs.Contains(slug));

        var newBlogs = missingSlugs.Select(slug => new BlogModel 
            { 
            Slug = slug,
            PageView = 0 
        });

        var blogModels = newBlogs.ToList();
        await context.Blogs.AddRangeAsync(blogModels);
        await context.SaveChangesAsync(); 
        
        return [.. existingBlogs, .. blogModels];
    }
}