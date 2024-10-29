using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RunModel
{
    public int RunId { get; set; }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public int RunCreatorId { get; set; }
    public string RunCreatorName { get; set; }
    public string RunName { get; set; }
    public string RunPassword { get; set; }
    public string RunDescription { get; set; }
    public int MaxPlayers { get; set; }
    public List<RunPlayerModel> RunPlayers { get; set; } = new List<RunPlayerModel>();
    public bool HasOpenSlots 
    { 
        get 
        { 
            if (RunPlayers.Count < MaxPlayers)
                return true;
            return false;
        }
    }
    public List<RunBattleModel> RunBattles{ get; set; } = new List<RunBattleModel>();
    public List<RunEncounterModel> RunEncounters { get; set; } = new List<RunEncounterModel>();
    public List<RunStepModel> RunProgression
    {
        get
        {
            //combines every encounter and battle into one list, and orders it by progression step
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
    public List<IGrouping<IProgressionOrderable, RunStepModel>> GroupedRunProgression
    {
        get
        {
            //groups every step by the progression step, so theres groups of progression steps for each run player
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
    public List<RunChatModel> RunChatMessages { get; set; } = new List<RunChatModel>();
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public bool RunComplete { get; set; }

}
