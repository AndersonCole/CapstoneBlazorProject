using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class BattleModel : IProgressionOrderable, IEquatable<BattleModel>
{
    public int BattleId { get; set; }
    public int GameId { get; set; }
    public string BattleName { get; set; }
    public string BattleLocation { get; set; }
    public string PokemonUsed { get; set; }
    public int HighestLevel { get; set; }
    public int ProgressionOrder { get; set; }
    public string ImageLink { get; set; }

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
