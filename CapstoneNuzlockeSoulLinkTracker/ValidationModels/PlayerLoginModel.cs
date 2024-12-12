using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

/// <summary>
/// Validation model providing error messages for logging in
/// </summary>
public class PlayerLoginModel
{
    [Required(ErrorMessage = "Username cannot be empty!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password cannot be empty!")]
    public string Password { get; set; }
}
