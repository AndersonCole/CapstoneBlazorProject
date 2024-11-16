using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class AdminGameStepModel : IEquatable<AdminGameStepModel>
{
    public IProgressionOrderable ProgressionStep { get; set; }
    public bool IsRoute { get; set; }
    public bool IsBattle { get; set; }
    public bool New { get; set; } = false;
    public bool Modified { get; set; } = false;
    public bool ToBeDeleted { get; set; } = false;

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
