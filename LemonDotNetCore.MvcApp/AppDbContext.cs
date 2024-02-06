using LemonDotNetCore.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LemonDotNetCore.RestAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}