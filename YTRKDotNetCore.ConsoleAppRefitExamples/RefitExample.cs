using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTRKDotNetCore.ConsoleAppRefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi service = RestService.For<IBlogApi>("https://localhost:7118");
        public async Task RunAsync()
        {
            //await CreateAsync("Refit Title", "Refit author", "Refit Content");
            //await UpdateAsync(28, "Update Refit Title", "Update Refit author", "Update Refit Content");
            //await DeleteAsync(24);
            //await EditAsync(444);
            await PatchAsync(28, "Patch Refit");
            await ReadAsync();
        }

        private async Task ReadAsync()
        {
            var lst = await service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Autor => {item.BlogAuthor}");
                Console.WriteLine($"BlogContent => {item.BlogContent}");
                Console.WriteLine("____________________________________");
            }
        }

        private async Task EditAsync(int id)
        {
            try
            {
                var item = await service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Autor => {item.BlogAuthor}");
                Console.WriteLine($"BlogContent => {item.BlogContent}");
                Console.WriteLine("____________________________________");
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string message = await service.CreateBlog(blog);
            Console.WriteLine(message);
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string message = await service.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task PatchAsync(int id, string? title = null, string? author = null, string? content = null)
        {
            try
            {
                BlogModel model = new BlogModel();

                if (!string.IsNullOrEmpty(title))
                {
                    model.BlogTitle = title;
                }
                if (!string.IsNullOrEmpty(author))
                {
                    model.BlogAuthor = author;
                }
                if (!string.IsNullOrEmpty(content))
                {
                    model.BlogContent = content;
                }

                string message = await service.PatchBlog(id, model);
                Console.WriteLine(message);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task DeleteAsync(int id)
        {
            try
            {
                string message = await service.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.StatusCode.ToString());
                Console.WriteLine(e.Content);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
