using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LemonDotNetCore.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet] 
        public IActionResult GetBLog ()
        {
            AppDbContext db = new AppDbContext ();   
            var lst = db.Blogs.ToList ();   
            return Ok(lst);
        }      
        [HttpPost] 
        public IActionResult CreateBLog ()
        {
            return Ok("post");
        }      
        [HttpPut] 
        public IActionResult UpdateBLog ()
        {
            return Ok("put");
        }      
        [HttpPatch] 
        public IActionResult PathBLog ()
        {
            return Ok("patch version");
        }       
        [HttpDelete] 
        public IActionResult DeleteBLog ()
        {
            return Ok("delete");
        }
    }
}
