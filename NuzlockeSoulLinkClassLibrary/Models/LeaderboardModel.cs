using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing the leaderboard
/// </summary>
public class LeaderboardModel
{
    /// <summary>
    /// Name of the player
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Amount of successful runs
    /// </summary>
    public int CompletedRuns { get; set; }
}
