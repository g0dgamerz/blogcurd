using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using blog.Models;
using blog.Interface;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _blogService;
        public BlogController(IBlog blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBlogs()
        {
            var blogList = _blogService.GetBlogs();
            var result = new ObjectResult(blogList);
            return result;  
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBlogById(int id)
        {
            Blog blog = new Blog();
            blog = _blogService.GetSingleBlog(id);
            return new ObjectResult(blog);
        }
        [HttpPost]
        public string Insert(Blog blog)
        {
            return _blogService.InsertBlog(blog);
        }
        [HttpPut("{id:int}")]
        public string Update(Blog blog,int id)
        {
            return _blogService.UpdateBlog(blog,id);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _blogService.DeleteBlog(id);
        }
    }
}
