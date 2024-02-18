using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
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
    }
}