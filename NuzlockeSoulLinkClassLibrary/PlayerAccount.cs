using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary
{
    public class PlayerAccount
    {
        public int Id { get; private set; }
        public string? Username { get; private set; }
        public bool IsAdmin { get; private set; }

        public void UpdateAccountInfo(PlayerModel player)
        {
            Id = player.PlayerId;
            Username = player.Username;
            IsAdmin = player.IsAdmin;
        }
    }
}
