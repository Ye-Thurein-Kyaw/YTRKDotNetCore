using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YTRKDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bl_blog;

        public BlogController()
        {
            _bl_blog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bl_blog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var lst = _bl_blog.GetBlog(id);

            if (lst is null)
            {
                return NotFound("No Data Fount");
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _bl_blog.CreateBlog(blog);
            string message = result > 0 ? "Saving SuccessFull" : "Save Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _bl_blog.GetBlog(id);

            if (item is null)
            {
                return NotFound("No Data Fount");
            }

            int result = _bl_blog.UpdateBlog(id, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _bl_blog.GetBlog(id);

            if (item is null)
            {
                return NotFound("No Data Fount");
            }

            int result = _bl_blog.PatchBlod(id, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _bl_blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Fount");
            }
            var result = _bl_blog.DeleteBlog(id);
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            return Ok(message);
        }
    }

    
}
