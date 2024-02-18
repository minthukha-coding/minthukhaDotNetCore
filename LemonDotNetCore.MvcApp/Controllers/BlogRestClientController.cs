using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;

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
            var lst = new List<BlogDataModel>();
            RestRequest restRequest = new RestRequest("api/blog", Method.Get);
            var responce = await _restClient.ExecuteAsync(restRequest);
            if (responce.IsSuccessStatusCode)
            {
                string jsonStr = responce.Content!;
                lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(jsonStr);
            }
            return View(lst);
        }
    }
}