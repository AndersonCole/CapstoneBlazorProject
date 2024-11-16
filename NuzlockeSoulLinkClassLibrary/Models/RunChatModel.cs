using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RunChatModel
{
    public int ChatId { get; set; }
    public int RunPlayerId { get; set; }
    public string PlayerName { get; set; }
    public string ChatMessage { get; set; }
    public DateTimeOffset TimeSent { get; set; }
}
