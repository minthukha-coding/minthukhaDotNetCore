using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class BlogRefitController : Controller
    {
        private readonly IBlogAPI _bogApi;
        public async Task<IActionResult> Index()
        {
            var lst = new List<BlogDataModel>();
            lst = await _bogApi.GetBlogs();
            return View();
        }
    }
}
