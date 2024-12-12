using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing the playersd in a run
/// </summary>
public class RunPlayerModel
{
    /// <summary>
    /// Id of the run player
    /// </summary>
    public int RunPlayerId { get; set; }
    /// <summary>
    /// Player id tied to the run
    /// </summary>
    public int PlayerId { get; set; }
    /// <summary>
    /// Username of the player
    /// </summary>
    public string PlayerName { get; set; }
    /// <summary>
    /// The last time a run player won, so they can only have a recorded victory every 10 minutes
    /// </summary>
    public DateTimeOffset LastWinTime { get; set; }
    /// <summary>
    /// the id of the run the players a part of
    /// </summary>
    public Guid RunId { get; set; }
}
