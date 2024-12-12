using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing logged in player account info
/// </summary>
public class PlayerAccount
{
    public int Id { get; private set; }
    public string? Username { get; private set; }
    public bool IsAdmin { get; private set; }

    /// <summary>
    /// Updates the player logged in data
    /// </summary>
    /// <param name="player"></param>
    public void UpdateAccountInfo(PlayerModel player)
    {
        Id = player.PlayerId;
        Username = player.Username;
        IsAdmin = player.IsAdmin;
    }

    /// <summary>
    /// Logs the user out
    /// </summary>
    public void LogoutUser()
    {
        Id = 0;
        Username = null;
        IsAdmin = false;
    }
}
