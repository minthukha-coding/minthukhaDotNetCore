using minthukhaDotNetCore.MvcApp.Models;
using Refit;

namespace minthukhaDotNetCore.MvcApp;

public interface IBlogAPI
{
    [Get("/api/blog")]
    Task<List<BlogDataModel>> GetBlogs();

    [Get("/api/blog/{id}")]
    Task<BlogDataModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogDataModel blog);

    [Put("/api/blog/{id}")]
    Task<string> UpdateBlog(int id, BlogDataModel blog);

    [Delete("/api/blog/{id}")]
    Task<string> DeleteBlog(int id);
}