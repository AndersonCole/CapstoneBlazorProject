using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class PlayerModel
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int CompletedRuns { get; set; } = 0;
        public bool IsAdmin { get; set; } = false;
    }
}
