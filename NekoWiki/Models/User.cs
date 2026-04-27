using System.ComponentModel.DataAnnotations;

namespace NekoWiki.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty; // Это твой "Login"

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public DateTime? BornDate { get; set; } // Для "Born Date"

    public string? FavoriteCats { get; set; } // Для "What cats do you like?"

    public string? CatLover { get; set; } // Для радиокнопок (Yes/No)

    public bool AcceptTerms { get; set; } // Для галочки условий
}