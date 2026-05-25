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
            // Находим путь к папке, где запущен сам проект
            string baseDirectory = AppContext.BaseDirectory;
            string dbPath = Path.Combine(baseDirectory, "nekowiki.db");

            // Подключаем базу по абсолютному, надежному пути
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}