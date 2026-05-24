using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NekoWiki.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace NekoWiki.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty] public string Username { get; set; } = string.Empty;
        [BindProperty] public string Email { get; set; } = string.Empty;
        [BindProperty] public string Password { get; set; } = string.Empty;
        [BindProperty] public DateTime BornDate { get; set; } = DateTime.Today;
        [BindProperty] public string FavCats { get; set; } = string.Empty;
        [BindProperty] public string LovesCats { get; set; } = "Yes";

        public string Message { get; set; } = string.Empty;

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
            {
                Message = "Please fill in all required fields!";
                return Page();
            }

            using (var db = new AppDbContext())
            {
                if (db.Users.Any(u => u.Username.ToLower() == Username.ToLower()))
                {
                    Message = "This username is already taken, nya!";
                    return Page();
                }

                var hasher = new PasswordHasher<string>();
                var newUser = new User
                {
                    Username = Username,
                    Email = Email,
                    PasswordHash = hasher.HashPassword(Username, Password),
                    BornDate = BornDate,
                    FavCats = FavCats,
                    LovesCats = LovesCats,
                    IsAdmin = false
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return RedirectToPage("/Login");
        }
    }
}