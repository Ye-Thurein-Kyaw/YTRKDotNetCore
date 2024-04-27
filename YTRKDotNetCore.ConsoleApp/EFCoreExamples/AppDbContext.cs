using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YTRKDotNetCore.ConsoleApp.Dtos;
using YTRKDotNetCore.ConsoleApp.Services;

namespace YTRKDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
