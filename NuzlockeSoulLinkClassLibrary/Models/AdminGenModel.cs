using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class AdminGenModel : IEquatable<AdminGenModel>
{
    public GenerationModel Gen { get; set; }
    public bool New { get; set; } = false;
    public bool Modified { get; set; } = false;
    public bool ToBeDeleted { get; set; } = false;

    public bool Equals(AdminGenModel other)
    {
        if (other == null)
            return false;

        if (this.Gen.GenId == other.Gen.GenId && this.Gen.RomanNumeral == other.Gen.RomanNumeral)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Gen.GenId, Gen.RomanNumeral);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        AdminGenModel genObj = obj as AdminGenModel;
        if (genObj == null)
            return false;
        return Equals(genObj);
    }
}
