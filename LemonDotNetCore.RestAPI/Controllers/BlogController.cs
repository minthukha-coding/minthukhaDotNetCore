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
        private Func<object, bool> x;

        [HttpGet] 
        public IActionResult GetBLogs()
        {
            //AppDbContext db = new AppDbContext ();   
            var lst = _dbContext.Blogs.ToList ();   
            return Ok(lst);
        }      

        [HttpGet("{id}")] 
        public IActionResult GetBLog (int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault( x => x.Blog_Id == id);   
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
        public IActionResult UpdateBLog()
        {
            return Ok();
        }

        [HttpPatch] 
        public IActionResult PathBLog ()
        {
            return Ok("patch version");
        }       

        [HttpDelete("{id}")] 
        public IActionResult DeleteBLog (int id)
        {
            var item = _dbContext.Blogs.FirstOrDefault(x => x.Blog_Id == id);
            if (item == null)
            {
                return BadRequest("No data is't foun");
            }
           _dbContext.Blogs.Remove(item);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Delete successful" : "Delete failed";
            return Ok("delete");
        }
    }
}