using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model for managing games from the admin page
/// </summary>
public class AdminGameModel : IEquatable<AdminGameModel>
{
    /// <summary>
    /// The game model
    /// </summary>
    public GameModel Game { get; set; }
    /// <summary>
    /// if the model has been newly added and needs to be inserted into the db
    /// </summary>
    public bool New { get; set; } = false;
    /// <summary>
    /// if the model was modififed, and already existed in the db
    /// </summary>
    public bool Modified { get; set; } = false;
    /// <summary>
    /// if the model is staged for deletion
    /// </summary>
    public bool ToBeDeleted { get; set; } = false;

    /// <summary>
    /// Functions for equality checking
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
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
