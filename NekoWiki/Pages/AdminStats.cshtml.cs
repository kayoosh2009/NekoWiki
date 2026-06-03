using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NekoWiki.Models;
using System.Collections.Generic;
using System.Linq;

namespace NekoWiki.Pages
{
    public class AdminStatsModel : PageModel
    {
        public int TotalVisits { get; set; } = 558;
        public int UserLogins { get; set; } = 2;
        public int OnlineNow { get; set; } = 1;

        // Список всех пользователей из БД
        public List<User> Users { get; set; } = new();

        public IActionResult OnGet()
        {
            var status = HttpContext.Session.GetString("status");
            if (status != "Admin") return RedirectToPage("/Index");

            using (var db = new AppDbContext())
            {
                Users = db.Users.OrderBy(u => u.Id).ToList();
            }

            return Page();
        }
    }
}
