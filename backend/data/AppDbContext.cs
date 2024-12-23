using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.data;

public class AppDbContext : DbContext
{
    public DbSet<BlogModel> Blogs { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    } 
}