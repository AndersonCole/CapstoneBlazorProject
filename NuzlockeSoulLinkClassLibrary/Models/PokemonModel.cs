using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model for pokemon data
/// </summary>
public class PokemonModel
{
    /// <summary>
    /// Dex number of the pokemon. For alt forms, uses the format PokeApi uses so that data can be searched
    /// </summary>
    public int DexNumber { get; set; }
    /// <summary>
    /// Name of the pokemon
    /// </summary>
    public string PokemonName { get; set; }
    /// <summary>
    /// Primary type of the pokemon
    /// </summary>
    public string PrimaryType { get; set; }
    /// <summary>
    /// Secondary type of the pokemon
    /// </summary>
    public string SecondaryType { get; set; }
    /// <summary>
    /// Dex number of the pokemon it evolves from
    /// null or 0 if this pokemon doesnt evolve from anything
    /// </summary>
    public int EvolvesFrom { get; set; }
    /// <summary>
    /// CSV string of any pokemon this one can evolve into
    /// Null or empty if there arent any evolutions
    /// </summary>
    public string EvolvesInto { get; set; }
}
