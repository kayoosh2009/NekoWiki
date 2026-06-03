using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NekoWiki.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime BornDate { get; set; }
        public string FavCats { get; set; } = string.Empty;
        public string LovesCats { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
    }

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dataDirectory = (string)AppDomain.CurrentDomain.GetData("DataDirectory")!;
            string dbPath = Path.Combine(dataDirectory, "nekowiki.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}