using LemonDotNetCore.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LemonDotNetCore.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private string _blogEndPoint = "https://localhost:7241/api/blog";
        public async Task Run()
        {
            //await Read();
            //await Edit(1020);
            await Edit(1083);
            //await Create("lemon title", "lemon author", "lemon content");
            //await Update(1083, "lemon", "lemon", "lemon");
            //await Patch(1083, "test", "test");
            //await Delete(1083);
        }
        #region Read
        public async Task Read()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_blogEndPoint, Method.Get);
            //await client.GetAsync(request);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
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
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
            //await client.GetAsync(request);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
            else
            {
                Console.WriteLine(response.Content);
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
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_blogEndPoint, Method.Post);
            request.AddBody(Blog);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
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

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(_blogEndPoint, Method.Post);
            request.AddBody(Blog);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
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
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
            request.AddBody(Blog);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content!);
        }
        #endregion

        #region Delete
        public async Task Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content!);
        }
        #endregion
    }
}