using Dapper;
using minthukhaDotNetCore.ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace minthukhaDotNetCore.ConsoleApp.DapperPractice;

public class DapperPractices
{
    private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "LemonDotNetCore",
        UserID = "sa",
        Password = "sasa@123"
    };

    public void Run()
    {
        //Read();
        //Edit(1024);
        Delete(11);
        //Create("Heol", "sdadf", "Hello Myanmar");
        //Update(2,"Hdfsfaeol", "23rasdadf", "3Hello Myanmar");
        //Update(111111,"fsaeHfeoasdfa el", "32r2sdadf", "gsdac Hello Myanmar");
    }

    private void Read()
    {
        string query = @"SELECT [Blog_Id]
                              ,[Blog_Title]
                              ,[Blog_Author]
                              ,[Blog_Content]
                          FROM [dbo].[Tbl_Blog]";
        using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();
        foreach (BlogDataModel item in lst)
        {
            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Content);
        }
    }

    private void Edit(int id)
    {
        string query = @"SELECT [Blog_Id]
                          ,[Blog_Title]
                          ,[Blog_Author]
                          ,[Blog_Content]
                      FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";
        using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        BlogDataModel? item = db.Query<BlogDataModel>(query, new BlogDataModel { Blog_Id = id }).FirstOrDefault();
        if (item is null)
        {
            Console.WriteLine("No data is not found");
            return;
        }
        Console.WriteLine(item.Blog_Id);
        Console.WriteLine(item.Blog_Title);
        Console.WriteLine(item.Blog_Author);
        Console.WriteLine(item.Blog_Content);
    }

    private void Create(string title, string author, string content)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "LemonDotNetCore",
            UserID = "sa",
            Password = "sasasu"
        };
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
                           ([Blog_Title]
                           ,[Blog_Author]
                           ,[Blog_Content])
                     VALUES
                           (@Blog_Title
                           ,@Blog_Author
                           ,@Blog_Content)";

        BlogDataModel blog = new BlogDataModel()
        {
            Blog_Title = title,
            Blog_Author = author,
            Blog_Content = content
        };

        using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Saving Successful." : "Saving failed";
        Console.WriteLine(message);
    }

    private void Update(int Id, string title, string author, string content)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "LemonDotNetCore",
            UserID = "sa",
            Password = "sasasu"
        };
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);


        string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [Blog_Title] = @Blog_Title
                              ,[Blog_Author] = @Blog_Author
                              ,[Blog_Content] = @Blog_Content
                         WHERE Blog_Id = @Blog_Id";

        BlogDataModel blog = new BlogDataModel()
        {
            Blog_Id = Id,
            Blog_Title = title,
            Blog_Author = author,
            Blog_Content = content
        };

        using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Updating Successful." : "Updating failed";
        Console.WriteLine(message);
    }

    private void Delete(int Id)
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "LemonDotNetCore",
            UserID = "sa",
            Password = "sasasu"
        };
        SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);


        string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE Blog_Id = @Blog_Id";

        BlogDataModel blog = new BlogDataModel()
        {
            Blog_Id = Id,
        };

        using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, blog);

        string message = result > 0 ? "Delete successful" : "Delete failed!!!";
        Console.WriteLine(message);
    }
}