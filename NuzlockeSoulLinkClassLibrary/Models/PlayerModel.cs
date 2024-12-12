using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a player
/// </summary>
public class PlayerModel
{
    /// <summary>
    /// Id of the player
    /// </summary>
    public int PlayerId { get; set; }
    /// <summary>
    /// Players username
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Players hashed and encrypted password
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Date the player was registered
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }
    /// <summary>
    /// Last time the player had a win registered, so that you can only have a win registered every 10 minutes
    /// </summary>
    public DateTimeOffset LastWinTime { get; set; }
    /// <summary>
    /// amount of completed runs
    /// </summary>
    public int CompletedRuns { get; set; } = 0;
    /// <summary>
    /// if the player is an admin
    /// </summary>
    public bool IsAdmin { get; set; } = false;
}
