using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; 

namespace NekoWiki.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public string? Message { get; set; }

        public void OnGet()
        {
            Message = "";
        }

        public IActionResult OnPost()
        {
            // Проверка учетных записей согласно спецификации
            // 3.1.1 Администратор
            if (Username == "admin" && Password == "admin123")
            {
                HttpContext.Session.SetString("username", "admin");
                HttpContext.Session.SetString("status", "Admin");
                return RedirectToPage("/Index");
            }
            // 3.1.2 Зарегистрированные пользователи
            else if (Username == "user1" && Password == "pass1")
            {
                HttpContext.Session.SetString("username", "user1");
                HttpContext.Session.SetString("status", "Registered");
                return RedirectToPage("/Index");
            }
            else if (Username == "user2" && Password == "pass2")
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