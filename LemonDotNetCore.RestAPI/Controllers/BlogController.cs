using LemonDotNetCore.RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _dbContext = new AppDbContext();
        [HttpGet]
        public IActionResult GetBLogs()
        {
            //AppDbContext db = new AppDbContext ();   
            var lst = _dbContext.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBLog(int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                return NotFound("No data not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBLog(BlogDataModel blog)
        {
            _dbContext.Blogs.Add(blog);
            var result = _dbContext.SaveChanges();
            var message = result > 0 ? "Saving Successful" : "Saving failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBLog(int id, BlogDataModel blog)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x=>x.Blog_Id == id); 

            if (item is null) {
               return NotFound("NO data is not found");
            }
            
            if (string.IsNullOrEmpty(blog.Blog_Title))
            {
                return BadRequest ("Blog title is required");
            }
            if (string.IsNullOrEmpty(blog.Blog_Author))
            {
                return BadRequest("Blog author is required");
            }
            if (string.IsNullOrEmpty(blog.Blog_Content))
            {
                return BadRequest("Blog content is required");
            }

            item.Blog_Title = blog.Blog_Title;
            item.Blog_Author = blog.Blog_Author;
            item.Blog_Content = blog.Blog_Content;

            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PathchBLog(int id,BlogDataModel blog)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null) {
                return NotFound("No data is not found!");
            }
            if (!string.IsNullOrEmpty(blog.Blog_Title)) {
                item.Blog_Title = blog.Blog_Title;
            }         
            if (!string.IsNullOrEmpty(blog.Blog_Author)) {
                item.Blog_Author = blog.Blog_Author;
            }         
            if (!string.IsNullOrEmpty(blog.Blog_Content)) {
                item.Blog_Content = blog.Blog_Content;
            }
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving failed";
            return Ok(message);    
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBLog(int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                return BadRequest("No data is't found");
            }
            _dbContext.Blogs.Remove(item);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Delete successful" : "Delete failed";
            return Ok("delete");
        }
    }
}