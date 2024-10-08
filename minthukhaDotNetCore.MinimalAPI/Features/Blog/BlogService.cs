using LemonDotNetCore.MinimalAPI;
using LemonDotNetCore.MinimalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LemonDotNetCore.MinimalApi.Features.Blog;

public static class BlogService
{
    public static IEndpointRouteBuilder UseBlogService(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/blog/{pageNo}/{pageSize}",
            async ([FromServicesAttribute] AppDbContext dbContext,
            int pageNo, int pageSize) =>
        {
            return await dbContext.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.Blog_Id)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        })
            .WithName("GetBlogs")
            .WithOpenApi();

        app.MapGet("/api/blog/{id}",
            async ([FromServicesAttribute] AppDbContext dbContext, int id) =>
        {
            var item = await dbContext.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Blog_Id == id);
            if (item is null)
            {
                return Results.NotFound("No data found.");
            }

            return Results.Ok(item);
        })
            .WithName("GetBlog")
            .WithOpenApi();

        app.MapPost("/api/blog", 
            async ([FromServicesAttribute] AppDbContext dbContext,
            [FromBody] BlogDataModel blog) =>
        {
            await dbContext.Blogs.AddAsync(blog);
            var result = await dbContext.SaveChangesAsync();
            var message = result > 0 ? "Saving Successful." : "Saving Failed";
            return Results.Ok(message);
        })
            .WithName("CreateBlog")
            .WithOpenApi();

        app.MapPut("/api/blog", 
            async ([FromServicesAttribute] AppDbContext dbContext,
            int id, BlogDataModel blog) =>
        {
            BlogDataModel? item = await dbContext.Blogs.FirstOrDefaultAsync(x => x.Blog_Id == id);
            if (item is null)
                return Results.NotFound("No data is not found");

            item.Blog_Title = blog.Blog_Title;
            item.Blog_Author = blog.Blog_Author;
            item.Blog_Content = blog.Blog_Content;

            var result = await dbContext.SaveChangesAsync();
            var message = result > 0 ? "Saving Successful." : "Saving Failed";
            return Results.Ok(message);
        })
            .WithName("UpdateBlog")
            .WithOpenApi();

        app.MapDelete("/api/blog/{id}", async ([FromServicesAttribute] AppDbContext dbContext, int id) =>
        {
            BlogDataModel? item = await dbContext.Blogs.FirstAsync(x => x.Blog_Id == id);
            if (item is null)
            {
                return Results.NotFound("No data found.");
            }

            dbContext.Blogs.Remove(item);
            int result = await dbContext.SaveChangesAsync();
            var message = result > 0 ? "Deleting Successful." : "Deleting Fail.";

            return Results.Ok(message);
        })

            .WithName("ီDeleteBlog")
            .WithOpenApi();

        return app;
    }
}
