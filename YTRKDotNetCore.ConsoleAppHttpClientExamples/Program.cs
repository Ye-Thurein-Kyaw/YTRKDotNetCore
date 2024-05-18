using Newtonsoft.Json;
using YTRKDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Hello, World!");

//Console App - Client (FontEnd)
//ASP.Net Core Web API - Server (BackEnd)


//HttpClient client = new HttpClient();
//HttpResponseMessage response =  await client.GetAsync("https://localhost:7056/api/blog");

////အပေါ် code မှာ async ပါတယ်  ဒီနေရာမှာ await ဆို တာကိုဖြုတ်လိုက်မယ်ဆိုရင် response က Task  ဆိုပီးပြောင်းသွားမယ်
//// Task က ဘာကြီးလဲဆိုတော့ အလုပ်တစ်ခုအနေနဲ့ဘဲ့ ဖြစ်သွားမာ တကယ်မလုပ်သွားဘူး လုပ်စေချင်ရင် await ပါမှ လုပ်လုပ်မှာ
//// Task ဖြစ်နေတဲ့ဟာကို run စေချင်တယ်ဆိုရင် task.RunSynchronously(); ဆိုမှ run သွားမာ

//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach (var item in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(item));
//        Console.WriteLine($"Title => {item.BlogTitle}");
//        Console.WriteLine($"Autor => {item.BlogAuthor}");
//        Console.WriteLine($"BlogContent => {item.BlogContent}");
//    }
//}

HttpClientExamples httpClientExample = new HttpClientExamples();
await httpClientExample.RunAsync();
Console.ReadLine();
