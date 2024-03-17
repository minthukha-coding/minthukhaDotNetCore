using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = new BlogDataModel();
            RestRequest restRequest = new RestRequest($"api/blog/{id}", Method.Get);
            var responce = await _restClient.ExecuteAsync(restRequest);
            if (responce.IsSuccessStatusCode)
            {
                string jsonStr = responce.Content!;
                item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr);
            }
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, BlogDataModel model)
        {
            RestRequest request = new($"/api/blog/{id}", Method.Put);
            request.AddJsonBody(model);
            var response = await _restClient.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            RestRequest request = new RestRequest($"/api/Blog/{id}", Method.Delete);

            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Blog post deleted successfully.";
                // Add some debugging output
                Console.WriteLine("Message set successfully");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Save(BlogDataModel model)
        {
            RestRequest request = new("/api/BLog", Method.Post);
            request.AddJsonBody(model);
            var response = await _restClient.ExecuteAsync(request);
            return RedirectToAction("Index");
        }
    }
}