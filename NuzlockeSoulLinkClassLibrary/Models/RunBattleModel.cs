using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// model representing a battle within a run, theres one run battle entry for each player in every run
/// </summary>
public class RunBattleModel
{
    /// <summary>
    /// Id of the run battle
    /// </summary>
    public int RunBattleId { get; set; }
    /// <summary>
    /// Id of the player the run is tied to
    /// </summary>
    public int RunPlayerId { get; set; }
    /// <summary>
    /// The battle model, containing all the details about the battle
    /// </summary>
    public BattleModel Battle { get; set; }
    /// <summary>
    /// override for the regular battles class, to be used in cases like randomizers where the battles are different
    /// </summary>
    public string PokemonUsed { get; set; }
    /// <summary>
    /// If the battle has been completed by this player
    /// </summary>
    public bool BattleCompleted { get; set; }
}
