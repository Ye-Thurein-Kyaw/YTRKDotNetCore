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
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetAdoBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdoBlog(int id)
        {
            var dt = FindById(id);

            if (dt is null)
            {
                return NotFound("No data found");
            }

            //DataRow dr = dt.Rows[0];
            //var item = new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //};

            return Ok(dt);
        }

        [HttpPost]
        public IActionResult CreateAdoBlog(BlogModel blog)
        {

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            //cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            //cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            //var result = cmd.ExecuteNonQuery();

            //connection.Close();

            int result = _adoDotNetService.Execute(query,
               new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
               new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
               new AdoDotNetParameter("@BlogContent", blog.BlogContent)
           );

            string message = result > 0 ? "Create Success" : "Create Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdoBlog(int id, BlogModel blog)
        {
            var dt = FindById(id);

            if (dt is null)
            {
                return NotFound("No data found to update");
            }

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            blog.BlogId = id;
            cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Update Success" : "update fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchAdoBlog(int id, BlogModel blog)
        {
            var dt = FindById(id);

            if (dt is null)
            {
                return NotFound("No data found to patch");
            }
            string conditions = string.Empty;

            if (!String.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
            }
            if (!String.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!String.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }

            if (conditions.Length == 0)
            {
                return NotFound("No param to patch");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {conditions}
 WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            blog.BlogId = id;
            cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);
            if (!String.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }

            if (!String.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }

            if (!String.IsNullOrEmpty(blog.BlogContent))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Patch Success" : "Patch fail";
            return Ok(message);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteAdoBlog(int id)
        {
            var dt = FindById(id);

            if (dt is null)
            {
                return NotFound("No data found to delete");
            }
            string query = @"DELETE FROM Tbl_Blog 
            WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Delete Success" : "Delete fail";
            return Ok(message);
        }

        private dynamic FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var dt = _adoDotNetService.Query<BlogModel>(query, parameters);


            var item = _adoDotNetService.QueryFirstOrDefalut<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //connection.Close();

            return item;
        }
    }
}
