using minthukhaDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace minthukhaDotNetCore.ConsoleApp.HttpClientExamples;

public class HttpClientExample
{
    private string _blogEndPoint = "https://localhost:7241/api/blog";

    public async Task Run()
    {
        //await Read();
        //await Edit(1007);
        //await Edit(1);
        //await Create("lemon title", "lemon author", "lemon content");
        //await Update(1082, "lemon", "lemon", "lemon");
        await Patch(6, "lemon", "lemon");
        await Delete(10811);
    }

    #region Read

    public async Task Read()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(_blogEndPoint);
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<BlogDataModel> lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(jsonStr)!;
            foreach (BlogDataModel item in lst)
            {
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
        }
    }

    #endregion

    #region Edit
    public async Task Edit(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"{_blogEndPoint}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;
            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
            Console.WriteLine(item.Blog_Author);
            Console.WriteLine(item.Blog_Content);
        }
        else
        {
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }

    #endregion

    #region Create

    public async Task Create(string title, string author, string content)
    {
        var Blog = new BlogDataModel
        {
            Blog_Title = title,
            Blog_Author = author,
            Blog_Content = content
        };

        string jsonBlog = JsonConvert.SerializeObject(Blog);
        HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync(_blogEndPoint, httpContent);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    #endregion

    #region Update

    public async Task Update(int id, string title, string author, string content)
    {
        var Blog = new BlogDataModel
        {
            Blog_Title = title,
            Blog_Author = author,
            Blog_Content = content
        };

        string jsonBlog = JsonConvert.SerializeObject(Blog);
        HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    #endregion

    #region Patch
    public async Task Patch(int id, string title, string author)
    {
        var Blog = new BlogDataModel
        {
            Blog_Id = id,
            Blog_Title = title,
            Blog_Author = author,
        };

        string jsonBlog = JsonConvert.SerializeObject(Blog);
        HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.PatchAsync($"{_blogEndPoint}/{id}", httpContent);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    #endregion

    #region Delete
    public async Task Delete(int id)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync($"{_blogEndPoint}/{id}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    #endregion
}