using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace YTRKDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExample
    {

        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7056"));
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            //await EditAsync(13);
            //await DeleteAsync(13);
            //await CreateAsync("title","author","content");
            //await UpdateAsync(26,"title edit","author","content");
            //await PatchAsync(26, "Title patch");
            await ReadAsync();
        }

        private async Task ReadAsync()
        {
            //RestRequest restRequest = new RestRequest(_blogEndpoint);
            //var response = await _client.GetAsync(restRequest);

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.GetAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
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
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Autor => {item.BlogAuthor}");
                Console.WriteLine($"BlogContent => {item.BlogContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };// C# object

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(model);
            var response = await _client.PostAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
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

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(model);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                var message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task PatchAsync(int id, string? title = null, string? author = null, string? content = null)
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

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Patch);
            restRequest.AddJsonBody(model);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
