using minthukhaDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace minthukhaDotNetCore.MvcApp.Controllers.Chart;

public class BlogRefitController : Controller
{
    private readonly IBlogAPI _blogApi;

    public BlogRefitController(IBlogAPI blogApi)
    {
        _blogApi = blogApi;
    }

    public async Task<IActionResult> Index()
    {
        var lst = new List<BlogDataModel>();
        lst = await _blogApi.GetBlogs();
        return View(lst);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var item = await _blogApi.GetBlog(id);
        return View(item);
    }
    public IActionResult Create()
    {
        return View();
    }
    public async Task<IActionResult> Save(BlogDataModel model)
    {
        string message = await _blogApi.CreateBlog(model);
        await Console.Out.WriteLineAsync(message);

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(int id, BlogDataModel model)
    {
        string message = await _blogApi.UpdateBlog(id, model);
        await Console.Out.WriteLineAsync(message);

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        string message = await _blogApi.DeleteBlog(id);
        await Console.Out.WriteLineAsync(message);

        return RedirectToAction("Index");

    }
}