using backend.data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class PageViewService (AppDbContext context) : IPageViewService
{
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
    
    public async Task<BlogModel> IncrementAsync(string slug)
    {
        var blogPost = await context.Blogs.FirstOrDefaultAsync(b => b.Slug == slug);

        if (blogPost is null)
        {
            blogPost = new BlogModel
            {
                Slug = slug,
                PageView = 0
            };
            
            await context.AddAsync(blogPost);
        }
            

        blogPost.PageView++;
        await context.SaveChangesAsync();
        
        return blogPost;
    }
}