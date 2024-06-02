﻿using Microsoft.EntityFrameworkCore;
using YTRKDotNetCore.NLayer.DataAccess.Models;

namespace YTRKDotNetCore.NLayer.DataAccess.Database
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
