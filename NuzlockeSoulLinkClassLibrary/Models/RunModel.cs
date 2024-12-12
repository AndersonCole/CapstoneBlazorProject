using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a run
/// </summary>
public class RunModel
{
    /// <summary>
    /// Id of the run
    /// </summary>
    public Guid RunId { get; set; }
    /// <summary>
    /// Id of the game the run is taking place in
    /// </summary>
    public int GameId { get; set; }
    /// <summary>
    /// Name of the game the run is for
    /// </summary>
    public string GameName { get; set; }
    /// <summary>
    /// Creator of the run's id
    /// </summary>
    public int RunCreatorId { get; set; }
    /// <summary>
    /// Creator of the runs name
    /// </summary>
    public string RunCreatorName { get; set; }
    /// <summary>
    /// Name of the run
    /// </summary>
    public string RunName { get; set; }
    /// <summary>
    /// Hashed and encryptted run password
    /// </summary>
    public string RunPassword { get; set; }
    /// <summary>
    /// Description of the run
    /// </summary>
    public string RunDescription { get; set; }
    /// <summary>
    /// Max amount of players that can be in a run
    /// </summary>
    public int MaxPlayers { get; set; }
    /// <summary>
    /// List of the players in the run
    /// </summary>
    public List<RunPlayerModel> RunPlayers { get; set; } = new List<RunPlayerModel>();
    /// <summary>
    /// Calculated bool for if theres open slots still in the run, and is therefore joinable
    /// </summary>
    public bool HasOpenSlots 
    { 
        get 
        { 
            if (RunPlayers.Count < MaxPlayers)
                return true;
            return false;
        }
    }
    /// <summary>
    /// The battles in the run for all players, there should be as many duplicate battles as there are players
    /// </summary>
    public List<RunBattleModel> RunBattles{ get; set; } = new List<RunBattleModel>();
    /// <summary>
    /// The encounters in the run for all players, there should be as many duplicate encounters as there are players
    /// </summary>
    public List<RunEncounterModel> RunEncounters { get; set; } = new List<RunEncounterModel>();
    /// <summary>
    /// Calculated list that combines every encounter and battle into one list, and orders it by progression step
    /// </summary>
    public List<RunStepModel> RunProgression
    {
        get
        {
            if (RunEncounters.Count != 0 && RunBattles.Count != 0)
            {
                List<RunStepModel> combinedProgression = RunEncounters.Select(r => new RunStepModel { 
                                                                                                        ProgressionStep = r.Route,
                                                                                                        RunPlayerId = r.RunPlayerId,
                                                                                                        IsRoute = true,
                                                                                                        RunEncounterId = r.EncounterId,
                                                                                                        DexNumber = r.DexNumber,
                                                                                                        PokemonName = r.PokemonName,
                                                                                                        IsAlive = r.IsAlive,
                                                                                                        IsBattle = false
                                                                                                    })
                                                                               .Concat(RunBattles.Select(b => new RunStepModel { 
                                                                                                                                    ProgressionStep = b.Battle,
                                                                                                                                    RunPlayerId = b.RunPlayerId,
                                                                                                                                    IsRoute = false,
                                                                                                                                    IsBattle = true,
                                                                                                                                    RunBattleId = b.RunBattleId,
                                                                                                                                    BattleCompleted = b.BattleCompleted
                                                                                                                               }))
                                                                               .OrderBy(step => step.ProgressionStep.ProgressionOrder)
                                                                               .ThenBy(step => step.RunPlayerId)
                                                                               .ToList();

                return combinedProgression;
            }
            else
                return new List<RunStepModel>();
        }
    }
    /// <summary>
    /// groups every step by the progression step, so theres groups of progression steps for each run player
    /// </summary>
    public List<IGrouping<IProgressionOrderable, RunStepModel>> GroupedRunProgression
    {
        get
        {
            if (RunProgression.Count != 0)
            {
                var groupedProgression = RunProgression.GroupBy(step => step.ProgressionStep)
                                         .ToList();

                return groupedProgression;
            }
            else
                return new List<IGrouping<IProgressionOrderable, RunStepModel>>();
        }
    }
    /// <summary>
    /// All the chat messages sent in the run chat
    /// </summary>
    public List<RunChatModel> RunChatMessages { get; set; } = new List<RunChatModel>();
    /// <summary>
    /// the date the run was created
    /// </summary>
    public DateTimeOffset CreatedDate { get; set; }
    /// <summary>
    /// any time something is updated in the run, this date updates. Used to keep most active and recent runs at the top of the active runs page
    /// </summary>
    public DateTimeOffset LastUpdated { get; set; }
    /// <summary>
    /// If the run has been ended in any way, through victory or defeat
    /// </summary>
    public bool RunComplete { get; set; }

}
