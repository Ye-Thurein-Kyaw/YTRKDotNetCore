// See https://aka.ms/new-console-template for more information
using YTRKDotNetCore.NLayer.DataAccess.Models;
using YTRKDotNetCore.RestApiWithNLayer.Features.Blog;

Console.WriteLine("Hello, World!");

BL_Blog bl_Blog = new BL_Blog();
BlogModel model = new BlogModel() {
    BlogTitle = "",
    BlogAuthor = "",
    BlogContent = "",
};
bl_Blog.CreateBlog(model);
 