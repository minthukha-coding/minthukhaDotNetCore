using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class BlogHttpClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogHttpClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
