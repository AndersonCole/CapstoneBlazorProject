using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model for managing generations in the admin page
/// </summary>
public class AdminGenModel : IEquatable<AdminGenModel>
{
    /// <summary>
    /// The generation model
    /// </summary>
    public GenerationModel Gen { get; set; }
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
