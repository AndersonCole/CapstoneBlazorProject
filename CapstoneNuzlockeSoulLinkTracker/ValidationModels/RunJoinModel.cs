using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

public class RunJoinModel
{
    public int MaxPlayers { get; set; }
    [Required(ErrorMessage = "Please enter a password!")]
    public string Password { get; set; }
}
