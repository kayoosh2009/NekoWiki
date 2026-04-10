using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NekoWiki.Pages
{
    public class AdminStatsModel : PageModel
    {
        // Убедись, что здесь нет дубликатов!
        public int TotalVisits { get; set; } = 0;
        public int UserLogins { get; set; } = 0;
        public int OnlineNow { get; set; } = 0; // Должна быть только одна такая строка

        public IActionResult OnGet()
        {
            var status = HttpContext.Session.GetString("status");
            if (status != "Admin") return RedirectToPage("/Index");

            return Page();
        }
    }
}