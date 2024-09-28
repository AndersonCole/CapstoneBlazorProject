using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class RunModel
    {
        public int RunId { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int RunCreatorId { get; set; }
        public string RunCreatorName { get; set; }
        public string RunName { get; set; }
        public string RunPassword { get; set; }
        public string RunDescription { get; set; }
        public bool IsMultiplayer { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public bool RunComplete { get; set; }

    }
}
