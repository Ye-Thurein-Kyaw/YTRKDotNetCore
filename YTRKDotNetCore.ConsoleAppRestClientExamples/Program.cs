using YTRKDotNetCore.ConsoleAppRestClientExamples;

Console.WriteLine("Hello, World!");

// RestClient ကိုသုံးမ်ဆိုရင် RestSharp ဆိုတဲ့ package ကိုသုံးပေးရမယ်

RestClientExample restClientExample = new RestClientExample();
await restClientExample.RunAsync();

Console.ReadLine();