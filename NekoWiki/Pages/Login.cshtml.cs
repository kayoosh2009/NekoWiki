using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; 

namespace NekoWiki.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "";
        }

        public IActionResult OnPost()
        {
            [cite_start]// Проверка учетных записей согласно спецификации [cite: 19, 20]

            [cite_start]if (Username == "admin" && Password == "admin123") // Админ [cite: 21]
            {
                HttpContext.Session.SetString("username", "admin");
                HttpContext.Session.SetString("status", "Admin");
                return RedirectToPage("/Index");
            }
            [cite_start]else if (Username == "user1" && Password == "pass1") // Пользователь 1 [cite: 22]
            {
                HttpContext.Session.SetString("username", "user1");
                HttpContext.Session.SetString("status", "Registered");
                return RedirectToPage("/Index");
            }
            [cite_start]else if (Username == "user2" && Password == "pass2") // Пользователь 2 [cite: 22]
            {
                HttpContext.Session.SetString("username", "user2");
                HttpContext.Session.SetString("status", "Registered");
                return RedirectToPage("/Index");
            }

            // Если данные не подошли
            Message = "Invalid username or password!";
            return Page();
        }
    }
}