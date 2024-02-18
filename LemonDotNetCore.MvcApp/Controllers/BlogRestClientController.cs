using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class BlogRestClientController : Controller
    {
        private readonly RestClient _restClient;

        public BlogRestClientController(RestClient restClient)
        {
            _restClient = restClient;
        }
        public async Task<IActionResult> Index()
        {
            List<BlogDataModel> lst = new();
            RestRequest request = new("/api/BlogDapper", Method.Get);
            var response = await _restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(jsonStr)!;
            }

            return View(lst);
        }
    }
}
