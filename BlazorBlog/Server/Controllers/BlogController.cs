using BlazorBlog.Server.Data;
using BlazorBlog.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;

        public BlogController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<List<BlogPost>> List()
        {
            return Ok(_context.BlogPost);
        }

        [HttpGet("{url}")]
        public ActionResult<BlogPost> Get(string url)
        {
            var post = _context.BlogPost.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("url not found");
            }
            return Ok(post);
        }




    }
}
