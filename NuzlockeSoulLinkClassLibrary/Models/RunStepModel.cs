using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Class representing both run encounters and run battles, as a single orderable object
/// </summary>
public class RunStepModel
{
    /// <summary>
    /// The data about the progression step, can be casted into either a battle or a route, depending on which flag is set
    /// </summary>
    public IProgressionOrderable ProgressionStep { get; set; }
    /// <summary>
    /// Id of the run player the step is tied to
    /// </summary>
    public int RunPlayerId { get; set; }
    /// <summary>
    /// If the step is a route
    /// </summary>
    public bool IsRoute { get; set; }
    /// <summary>
    /// id of the run encounter
    /// only set if IsRoute is true
    /// </summary>
    public int RunEncounterId { get; set; }
    /// <summary>
    /// Dex number of the encountered pokemon
    /// only set if IsRoute is true
    /// </summary>
    public int DexNumber { get; set; }
    /// <summary>
    /// Name of the encountered pokemon
    /// only set if IsRoute is true
    /// </summary>
    public string PokemonName { get; set; }
    /// <summary>
    /// Status of the pokemon as a 0, 1, 2 int
    /// only set if IsRoute is true
    /// </summary>
    public int IsAlive { get; set; }
    /// <summary>
    /// If the setp is a battle
    /// </summary>
    public bool IsBattle { get; set; }
    /// <summary>
    /// Id of the run battle
    /// only set if IsBattle is true
    /// </summary>
    public int RunBattleId { get; set; }
    /// <summary>
    /// If the battle has been completed
    /// only set if IsBattle is true
    /// </summary>
    public bool BattleCompleted { get; set; }
    /// <summary>
    /// Only used for encounters, needed so the list of available pokemon to choose from can be filtered
    /// </summary>
    public string SearchQuery { get; set; } = "";
    /// <summary>
    /// The filtered list of pokemon based on the search query
    /// </summary>
    public List<PokemonModel> FilteredPokemon { get; set; } = new List<PokemonModel>();
}
