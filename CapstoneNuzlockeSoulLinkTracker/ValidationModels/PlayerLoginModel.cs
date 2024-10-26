using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

public class PlayerLoginModel
{
    [Required(ErrorMessage = "Username cannot be empty!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password cannot be empty!")]
    public string Password { get; set; }
}
