using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YTRKDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExamples
    {

      private readonly  HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7056") };
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            //await EditAsync(22);
            //await DeleteAsync(22);
            //await CreateAsync("title","author","content");
            //await UpdateAsync(2,"title","author","content");
            await PatchAsync(2, "Title patch");
          await  ReadAsync();
        }

        private async Task ReadAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Autor => {item.BlogAuthor}");
                    Console.WriteLine($"BlogContent => {item.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Autor => {item.BlogAuthor}");
                    Console.WriteLine($"BlogContent => {item.BlogContent}");
            }
            else { 
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            // C# object
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            // to Json
            string blogJson = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(blogJson,Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndpoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel model = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task PatchAsync(int id, string? title = null, string? author = null, string? content = null)
        {
            BlogModel model = new BlogModel();

            if(!string.IsNullOrEmpty(title))
             {
                model.BlogTitle = title;
            }
            if(!string.IsNullOrEmpty(author))
             {
                model.BlogAuthor = author;
            }
            if(!string.IsNullOrEmpty(content))
             {
              model.BlogContent = content;
            }

            string blogJson = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PatchAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
