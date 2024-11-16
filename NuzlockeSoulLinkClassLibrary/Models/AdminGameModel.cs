using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class AdminGameModel : IEquatable<AdminGameModel>
{
    public GameModel Game { get; set; }
    public bool New { get; set; } = false;
    public bool Modified { get; set; } = false;
    public bool ToBeDeleted { get; set; } = false;

    public bool Equals(AdminGameModel other)
    {
        if (other == null)
            return false;

        if (this.Game.GameId == other.Game.GameId && this.Game.GenId == other.Game.GenId &&
            this.Game.GameName == other.Game.GameName && this.Game.Abbreviation == other.Game.Abbreviation)
        { 
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Game.GenId, Game.GameId, Game.GameName, Game.Abbreviation);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        AdminGameModel gameObj = obj as AdminGameModel;
        if (gameObj == null)
            return false;
        return Equals(gameObj);
    }
}
