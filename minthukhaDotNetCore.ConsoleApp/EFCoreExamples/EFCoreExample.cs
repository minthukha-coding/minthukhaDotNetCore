using minthukhaDotNetCore.ConsoleApp.Models;

namespace minthukhaDotNetCore.ConsoleApp.EFCoreExamples;

public class EFCoreExample
{
    private readonly AppDbContext _dbContext = new AppDbContext();

    public void Run()
    {
        //Delete(10);
        //Edit(10);
        //Create("2", "2", "22");
        //Update(9, "hg", "dafa asdfas");
        //Edit(9);
        //Update(111111, "fsaeHfeoasdfa el", "32r2sdadf", "gsdac Hello Myanmar");
    }

    private void Read()
    {
        var lst = _dbContext.Blogs.ToList();
        foreach (BlogDataModel item in lst)
        {
            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Content);
        }
    }

    public void Edit(int id)
    {
        BlogDataModel? item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
        if (item == null)
        {
            Console.WriteLine("No data not found!");
            return;
        }
        Console.WriteLine(item.Blog_Id);
        Console.WriteLine(item.Blog_Title);
        Console.WriteLine(item.Blog_Author);
        Console.WriteLine(item.Blog_Content);
    }

    public void Create(string title, string author, string content)
    {
        BlogDataModel blog = new BlogDataModel()
        {
            Blog_Title = title,
            Blog_Author = author,
            Blog_Content = content
        };
        _dbContext.Blogs.Add(blog);
        int result = _dbContext.SaveChanges();
        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        BlogDataModel? item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        item.Blog_Title = title;
        item.Blog_Author = author;
        item.Blog_Content = content;

        int result = _dbContext.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        BlogDataModel? item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        _dbContext.Blogs.Remove(item);
        int result = _dbContext.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}