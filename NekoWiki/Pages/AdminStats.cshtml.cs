using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NekoWiki.Pages
{
    public class AdminStatsModel : PageModel
    {
        // Убедись, что здесь нет дубликатов!
        public int TotalVisits { get; set; } = 558;
        public int UserLogins { get; set; } = 2;
        public int OnlineNow { get; set; } = 1; 

        public IActionResult OnGet()
        {
            var status = HttpContext.Session.GetString("status");
            if (status != "Admin") return RedirectToPage("/Index");

            return Page();
        }
    }
}