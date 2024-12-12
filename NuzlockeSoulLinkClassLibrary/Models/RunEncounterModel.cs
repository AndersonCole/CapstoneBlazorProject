using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// model representing an encounter where a pokemon can be caught within a run, theres one run encounter entry for each player in every run
/// </summary>
public class RunEncounterModel
{
    /// <summary>
    /// id of the run encounter
    /// </summary>
    public int EncounterId { get; set; }
    /// <summary>
    /// id of the run player
    /// </summary>
    public int RunPlayerId { get; set; }
    /// <summary>
    /// Data about where the encounter took place
    /// </summary>
    public RouteModel Route { get; set; }
    /// <summary>
    /// Dex number of the encounter pokemon
    /// </summary>
    public int DexNumber { get; set; }
    /// <summary>
    /// Name of the pokemon
    /// </summary>
    public string PokemonName { get; set; }
    /// <summary>
    /// An int representing the pokemons status, 
    /// 0 = not encountered yet,
    /// 1 = Captured and alive
    /// 2 = fainted, and now unsuable
    /// </summary>
    public int IsAlive { get; set; }
}
