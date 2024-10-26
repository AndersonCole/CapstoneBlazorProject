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
    public List<IProgressionOrderable> RunProgression
    {
        get
        {
            if (RunEncounters.Count != 0 && RunBattles.Count != 0)
            {
                List<IProgressionOrderable> combinedProgression = RunEncounters.Select(r => r.Route as IProgressionOrderable)
                                                                               .Concat(RunBattles.Select(b => b.Battle as IProgressionOrderable))
                                                                               .OrderBy(step => step.ProgressionOrder)
                                                                               .ToList();

                return combinedProgression;
            }
            else
                return new List<IProgressionOrderable>();
        }
    }
    public List<RunChatModel> RunChatMessages { get; set; } = new List<RunChatModel>();
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastUpdated { get; set; }
    public bool RunComplete { get; set; }

}
