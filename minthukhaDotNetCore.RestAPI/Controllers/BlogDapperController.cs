using Dapper;
using minthukhaDotNetCore.RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace minthukhaDotNetCore.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogDapperController : ControllerBase
{
    private readonly System.Data.SqlClient.SqlConnectionStringBuilder sqlConnectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "LemonDotNetCore",
        UserID = "sa",
        Password = "sasa@123"
    };

    [HttpGet]
    public IActionResult GetBLogs()
    {
        string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog]";
        using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();
        return Ok(lst);
    }


    [HttpGet("{id}")]
    public IActionResult GetBLog(int id)
    {
        string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]`
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";

        using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        BlogDataModel? item = db.Query<BlogDataModel>(query, new BlogDataModel { Blog_Id = id }).FirstOrDefault();
        if (item is null)
        {
            return BadRequest("No data not found");
        }
        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateBlog(BlogDataModel blog)
    {
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([Blog_Title]
                           ,[Blog_Author]
                           ,[Blog_Content])
                     VALUES
                           (@Blog_Title
                           ,@Blog_Author
                           ,@Blog_Content)";
        using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        return Ok(message);
    }

    [HttpPut("{id}")]
    public IActionResult UpdataBlog(int id, BlogDataModel blog)
    {
        using IDbConnection db = new Microsoft.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";

        BlogDataModel? item = db.Query<BlogDataModel>(query, new BlogDataModel { Blog_Id = id }).FirstOrDefault();
        if (item is null)
        {
            return NotFound("No data is not found");
        }

        if (string.IsNullOrEmpty(blog.Blog_Title))
        {
            return BadRequest("Blog Title is required.");
        }
        if (string.IsNullOrEmpty(blog.Blog_Author))
        {
            return BadRequest("Blog Author is required.");
        }
        if (string.IsNullOrEmpty(blog.Blog_Content))
        {
            return BadRequest("Blog Content is required.");
        }

        blog.Blog_Id = id;

        string queryUpdate = @"UPDATE [dbo].[Tbl_Blog]
                                   SET [Blog_Title] = @Blog_Title
                                      ,[Blog_Author] = @Blog_Author
                                      ,[Blog_Content] = @Blog_Content
                                 WHERE Blog_Id = @Blog_Id";
        int result = db.Execute(queryUpdate, blog);
        string message = result > 0 ? "Saving successful" : "Saving failed";
        return (Ok(message));
    }
    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogDataModel blog)
    {
        using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";

        BlogDataModel? item = db.Query<BlogDataModel>(query, new BlogDataModel { Blog_Id = id }).FirstOrDefault();
        if (item is null)
        {
            return NotFound("No data is not found");
        }

        blog.Blog_Id = id;

        string conditions = string.Empty;
        if (!string.IsNullOrEmpty(blog.Blog_Title))
        {
            conditions += @"[Blog_Title] = @Blog_Title, ";
        }
        if (!string.IsNullOrEmpty(blog.Blog_Author))
        {
            conditions += @"[Blog_Author] = @Blog_Author, ";
        }
        if (!string.IsNullOrEmpty(blog.Blog_Content))
        {
            conditions += @"[Blog_Content] = @Blog_Content, ";
        }

        if (conditions.Length == 0)
        {
            return BadRequest("Invalid req!");
        }

        //conditions = conditions.Substring(0, conditions.Length - 2);
        blog.Blog_Id = id;
        string queryUpdate = $@"UPDATE [dbo].[Tbl_Blog]
                                   SET {conditions}
                                 WHERE Blog_Id = @Blog_Id";
        int result = db.Execute(queryUpdate, blog);
        string message = result > 0 ? "Saving successful" : "Saving failed";
        return (Ok(message));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        string query = @"DELETE FROM [dbo].[Tbl_Blog]
                              WHERE Blog_Id = @Blog_Id";

        BlogDataModel blog = new BlogDataModel()
        {
            Blog_Id = id,
        };
        using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

        return Ok(message);
    }
}