using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model for managing progression steps in the admin page
/// </summary>
public class AdminGameStepModel : IEquatable<AdminGameStepModel>
{
    /// <summary>
    /// Can be either a route or battle model, depending on the other set booleans
    /// </summary>
    public IProgressionOrderable ProgressionStep { get; set; }
    /// <summary>
    /// true if the ProgressionStep is a route
    /// </summary>
    public bool IsRoute { get; set; }
    /// <summary>
    /// true if the ProgressionStep is a battle
    /// </summary>
    public bool IsBattle { get; set; }
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
    public bool Equals(AdminGameStepModel other)
    {
        if (other == null)
            return false;

        if (this.IsRoute && other.IsRoute)
        {
            if (this.ProgressionStep as RouteModel == other.ProgressionStep as RouteModel)
                return true;
        }
        else if (this.IsBattle && other.IsBattle)
        {
            if (this.ProgressionStep as BattleModel == other.ProgressionStep as BattleModel)
                return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        if (IsRoute)
        {
            return HashCode.Combine((ProgressionStep as RouteModel).GetHashCode(), IsRoute, IsBattle);
        }
        else if (IsBattle)
        {
            return HashCode.Combine((ProgressionStep as BattleModel).GetHashCode(), IsRoute, IsBattle);
        }
        return HashCode.Combine(ProgressionStep, IsRoute, IsBattle);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        AdminGameStepModel stepObj = obj as AdminGameStepModel;
        if (stepObj == null)
            return false;
        return Equals(stepObj);
    }
}
