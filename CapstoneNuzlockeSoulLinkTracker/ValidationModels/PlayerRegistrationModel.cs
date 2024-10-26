using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

public class PlayerRegistrationModel
{
    [Required(ErrorMessage = "Username cannot be empty!")]
    [StringLength(25, ErrorMessage = "Username is too long!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password cannot be empty!")]
    [StringLength(25, ErrorMessage = "Password is too long!")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Enter your password again!")]
    [Compare("Password", ErrorMessage = "Passwords must match!")]
    public string ConfirmPassword { get; set; }
}
