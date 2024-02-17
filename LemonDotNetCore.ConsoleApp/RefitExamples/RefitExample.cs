using LemonDotNetCore.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonDotNetCore.ConsoleApp.ReflitExamples
{
    public class RefitExample
    {
        private readonly IBlogAPI _blogAPI = RestService.For<IBlogAPI>("https://localhost:7241");

        public async Task Run()
        {
            //await Read();
            //await Edit(1084);
            //await Delete(8);
            //await Edit(103252384);
            //await Create("lawoneain", "lawoneain", "lawoneain");
            //await Update(8, "hello", "ူ့hello", "ူ့hello");
            //await Update(1082, "lemon", "lemon", "lemon");
        }

        public async Task Read()
        {
            var lst = await _blogAPI.GetBlogs();
            foreach (BlogDataModel item in lst)
            {
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
        }
        public async Task Edit(int id)
        {
            try
            {
                var item = await _blogAPI.GetBlog(id);
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content!.ToString());
                Console.WriteLine(ex.ReasonPhrase!.ToString());
            }
        }
        public async Task Create(string title, string author, string content)
        {
            var message = await _blogAPI.CreateBlog(new BlogDataModel
            {
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            });

            Console.WriteLine(message);
        }
        public async Task Update(int id, string title, string author, string content)
        {
            try
            {
                var message = await _blogAPI.UpdateBlog(id, new BlogDataModel
                {
                    Blog_Id = id,
                    Blog_Title = title,
                    Blog_Author = author,
                    Blog_Content = content
                });
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content!.ToString());
                Console.WriteLine(ex.ReasonPhrase!.ToString());
            }

        }
        public async Task Delete(int id)
        {
            try
            {
                var message = await _blogAPI.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.ReasonPhrase!.ToString());
            }

        }
    }
}