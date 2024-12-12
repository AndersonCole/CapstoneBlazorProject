using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// model for chat messages in the run
/// </summary>
public class RunChatModel
{
    /// <summary>
    /// Id of the chat message
    /// </summary>
    public int ChatId { get; set; }
    /// <summary>
    /// Run player id of the sender of the message
    /// </summary>
    public int RunPlayerId { get; set; }
    /// <summary>
    /// Username of the message sender
    /// </summary>
    public string PlayerName { get; set; }
    /// <summary>
    /// Chat message content
    /// </summary>
    public string ChatMessage { get; set; }
    /// <summary>
    /// the time the message was sent
    /// </summary>
    public DateTimeOffset TimeSent { get; set; }
}
