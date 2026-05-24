using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using NekoWiki.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace NekoWiki.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password { get; set; }
        public string? Message { get; set; }

        public void OnGet() { Message = ""; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Message = "Please enter username and password!";
                return Page();
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == Username);
                if (user != null)
                {
                    var hasher = new PasswordHasher<string>();
                    var result = hasher.VerifyHashedPassword(Username, user.PasswordHash, Password);

                    if (result == PasswordVerificationResult.Success)
                    {
                        HttpContext.Session.SetString("username", user.Username);
                        HttpContext.Session.SetString("status", user.IsAdmin ? "Admin" : "Registered");
                        return RedirectToPage("/Index");
                    }
                }
            }

            Message = "Invalid username or password, nya!";
            return Page();
        }
    }
}