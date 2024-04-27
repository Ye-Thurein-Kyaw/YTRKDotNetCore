using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTRKDotNetCore.ConsoleApp.Dtos;

namespace YTRKDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {

        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {

            //Edit(11);
            //Edit(34);

            //Create("EFCore title", "EFCore auth", "EFCore Context");

            //Update(18, "EFCore Update", "update efcore auth", "update efore context");

            Delete(33);

            Read();
        }

        private void Read()
        {
            var lst = db.Blogs.ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("---------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges(); //ဒါက query မှာဆိုရင် exclude ကိုနှိပ်ပါဆိုတဲ့သဘော
            string message = result > 0 ? "Create Success" : "Create fail";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Fount");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update Success" : "Update Fail";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Delete Success" : "Delete Fail";
            Console.WriteLine(message);
        }
    }
}
