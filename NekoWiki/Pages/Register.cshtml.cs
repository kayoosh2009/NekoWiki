using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NekoWiki.Data;
using NekoWiki.Models;

namespace NekoWiki.Pages;

public partial class RegisterModel : PageModel
{
    private readonly ApplicationDbContext _context;

    // Конструктор: именно здесь база данных "передается" в твой файл
    public RegisterModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public User NewUser { get; set; } = default!;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Проверяем, заполнил ли пользователь все обязательные поля
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Добавляем котика-пользователя в базу
        _context.Users.Add(NewUser);
        
        // Сохраняем изменения в файл school.db
        await _context.SaveChangesAsync();

        // После успеха отправляем на главную
        return RedirectToPage("/Index");
    }
}