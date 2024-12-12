using minthukhaDotNetCore.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace minthukhaDotNetCore.MVCApp;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<BlogDataModel> Blogs { get; set; }
}