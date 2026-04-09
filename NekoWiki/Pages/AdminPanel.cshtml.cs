using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NekoWiki.Pages
{
    public class AdminStatsModel : PageModel
    {
        // Данные для статистики (согласно пункту 4.4)
        public int TotalVisits { get; set; }
        public int RegisteredVisits { get; set; }
        public int OnlineNow { get; set; }

        public IActionResult OnGet()
        {
            // Проверка прав (Пункт 4.1)
            var status = HttpContext.Session.GetString("status");
            if (status != "Admin")
            {
                return RedirectToPage("/Index");
            }

            // Пока данных нет в БД, ставим примерные числа (Пункт 4.4.1, 4.4.2)
            TotalVisits = 150;      // Всего входов
            RegisteredVisits = 85;  // Входы зарегистрированных
            OnlineNow = 3;          // Сейчас на сайте

            return Page();
        }
    }
}