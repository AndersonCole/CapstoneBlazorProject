using System.ComponentModel.DataAnnotations;

namespace CapstoneNuzlockeSoulLinkTracker.ValidationModels;

/// <summary>
/// Validation model providing error messages for chat messages
/// </summary>
public class RunChatValidationModel
{
    [Required(ErrorMessage = "Type a message to send!")]
    [StringLength(255, ErrorMessage = "Message must be less than 255 characters!")]
    public string ChatMessage { get; set; }
}
