using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

public class RunJoinModel
{
    [Required(ErrorMessage = "Please enter a password!")]
    public string Password { get; set; }
}
