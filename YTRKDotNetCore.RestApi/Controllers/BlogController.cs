using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using YTRKDotNetCore.RestApi.Database;
using YTRKDotNetCore.RestApi.Models;

namespace YTRKDotNetCore.RestApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _context.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var lst = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (lst is null)
            {
                return NotFound("No Data Fount");
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result = _context.SaveChanges();

            string message = result > 0 ? "Saving SuccessFull" : "Save Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return NotFound("No Data Fount");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _context.SaveChanges();
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Fount");
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {

                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogContent = blog.BlogContent;
            }

            int result = _context.SaveChanges();
            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No Data Fount");
            }
            _context.Blogs.Remove(item);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            return Ok(message);
        }
    }
}
