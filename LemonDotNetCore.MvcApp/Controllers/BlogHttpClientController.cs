<<<<<<< HEAD
﻿using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection.Metadata;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> parent of 8ac0809 (.)

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
        public async Task<IActionResult> Edit(int id)
        {
            var item = new BlogDataModel();
            var response = await _httpClient.GetAsync($"api/blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;
            }
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Save(BlogDataModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Blog", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                await Console.Out.WriteLineAsync(message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Blog/{id}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, BlogDataModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, Application.Json);
            HttpResponseMessage response = await _httpClient.PutAsync($"/api/Blog/{id}", httpContent);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return RedirectToAction("Index");
        }
    }
}
