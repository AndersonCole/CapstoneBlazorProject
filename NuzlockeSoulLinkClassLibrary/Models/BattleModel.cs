using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a battle, usually a gym leader battle, extends IProgressionOrderable so it can be sorted with Route models
/// </summary>
public class BattleModel : IProgressionOrderable, IEquatable<BattleModel>
{
    /// <summary>
    /// Id of the battle
    /// </summary>
    public int BattleId { get; set; }
    /// <summary>
    /// Id of the game the battles from
    /// </summary>
    public int GameId { get; set; }
    /// <summary>
    /// Name of the battle, usualy the name of the gym leader for the area
    /// </summary>
    public string BattleName { get; set; }
    /// <summary>
    /// Location of the battle, usually the town the gym is in
    /// </summary>
    public string BattleLocation { get; set; }
    /// <summary>
    /// The pokemon the trainer uses, a CSV string
    /// </summary>
    public string PokemonUsed { get; set; }
    /// <summary>
    /// the highest level of any pokemon used. Lets players know what the highest level mon they could use is
    /// </summary>
    public int HighestLevel { get; set; }
    /// <summary>
    /// Order the battle appears in progression, higher number = later in progression
    /// </summary>
    public int ProgressionOrder { get; set; }
    /// <summary>
    /// Link to an image to represent the battle
    /// </summary>
    public string ImageLink { get; set; }

    /// <summary>
    /// Functions for equality checking
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(BattleModel other)
    {
        if (other == null)
            return false;

        if (this.BattleId == other.BattleId && this.GameId == other.GameId && 
            this.BattleName == other.BattleName && this.BattleLocation == other.BattleLocation &&
            this.PokemonUsed == other.PokemonUsed && this.HighestLevel == other.HighestLevel &&
            this.ProgressionOrder == other.ProgressionOrder && this.ImageLink == other.ImageLink)
            return true;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BattleId, GameId, BattleName, BattleLocation, PokemonUsed,
                                HighestLevel, ProgressionOrder, ImageLink);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        BattleModel battleObj = obj as BattleModel;
        if (battleObj == null)
            return false;
        return Equals(battleObj);
    }
}
