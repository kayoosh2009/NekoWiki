using System.ComponentModel.DataAnnotations;

namespace NekoWiki.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Login { get; set; } = string.Empty; // inputLogin 

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty; // inputEmail [cite: 36]

    [Required]
    public string Password { get; set; } = string.Empty; // inputPassword 

    public DateTime BornDate { get; set; } // inputDOB 

    public string FavoriteCats { get; set; } = string.Empty; // favCats 

    public string CatLover { get; set; } = string.Empty; // catLover (Yes/No) 
}