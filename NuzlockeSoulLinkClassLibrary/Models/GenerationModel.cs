using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a generation
/// </summary>
public class GenerationModel
{
    /// <summary>
    /// Id of the gen
    /// </summary>
    public int GenId { get; set; }
    /// <summary>
    /// Roman numeral display of the generations number
    /// </summary>
    public string RomanNumeral { get; set; }
}
