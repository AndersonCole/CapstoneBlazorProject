using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

/// <summary>
/// Validation model providing error messages for joining a run
/// </summary>
public class RunJoinModel
{
    [Required(ErrorMessage = "Please enter a password!")]
    public string Password { get; set; }
}
