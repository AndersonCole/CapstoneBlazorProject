using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class RunChatModel
    {
        public int ChatId { get; set; }
        public int PlayterId { get; set; }
        public int RunId { get; set; }
        public string ChatMessage { get; set; }
        public DateTimeOffset TimeSent { get; set; }
    }
}
