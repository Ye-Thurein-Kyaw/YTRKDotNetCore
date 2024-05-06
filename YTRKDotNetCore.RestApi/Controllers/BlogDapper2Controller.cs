using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using YTRKDotNetCore.RestApi.Models;
using YTRKDotNetCore.Shared;

namespace YTRKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {

        private readonly DapperService _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        // ဒီလို တခြား project က ဟာကို ခေါ်သုံးမယ်ဆိုရင် လက်ရှိ pj ရဲ့ Dependences ကို right click -> add project reference နှိပ်ပီး project ကို check လုပ်ပေးရမယ် 

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            List<BlogModel> lst = _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindById(id);

            if (item == null)
            {
                return NotFound("No Data Fount");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var result = db.Execute(query, blog);

            var result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Create Success" : "Create fail";

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id , BlogModel blog) 
        {
           var item = FindById(id);

            if (item == null)
            {
                return NotFound("No Data Fount");
            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            blog.BlogId = id;
        int  result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Update Success" : "Update Fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog) 
        {
            var item = FindById(id);

            if (item == null)
            {
                return NotFound("No Data Fount");
            }

            string  conditions = string.Empty;

            if(!String.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
            }   
            if(!String.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }   
            if(!String.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }      

            if(conditions.Length == 0)
            {
                return NotFound("No data to update");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {conditions}
 WHERE BlogId = @BlogId";
            blog.BlogId = id;

            var result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Patch Success" : "Patch Fail";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id) 
        {
            var item = FindById(id);
            if (item == null)
            {
                return NotFound("No Data Found");
            }
            string query = @"Delete From [dbo].[Tbl_Blog] where BlogId = @BlogId";
            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            return Ok(message);
        }


        private BlogModel? FindById(int id)
        {
            //using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogModel>("select * from tbl_blog where blogid = @BlogId", new BlogModel { BlogId = id }).FirstOrDefault();
            string query = "select * from tbl_blog where blogid = @BlogId";
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });

            return item;
        }
    }
}
