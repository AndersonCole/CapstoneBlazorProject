using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

/// <summary>
/// Validation model providing error messages for creating a run
/// </summary>
public class RunCreationModel
{
    [Required(ErrorMessage = "Run Name cannot be empty!")]
    [StringLength(50, ErrorMessage = "Run Name is too long!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Game must be selected!")]
    public int GameId { get; set; }
    [Required(ErrorMessage = "Max amount of players must be selected!")]
    public int MaxPlayers { get; set; }
    [Required(ErrorMessage = "Password cannot be empty!")]
    [StringLength(25, ErrorMessage = "Password is too long!")]
    public string Password { get; set; }
    [StringLength(255, ErrorMessage = "Description is too long!")]
    public string Description { get; set; }
}
