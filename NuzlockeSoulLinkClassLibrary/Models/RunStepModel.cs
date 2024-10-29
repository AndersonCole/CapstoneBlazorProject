using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RunStepModel
{
    public IProgressionOrderable ProgressionStep { get; set; }
    public int RunPlayerId { get; set; }
    public bool IsRoute { get; set; }
    public int RunEncounterId { get; set; }
    public int DexNumber { get; set; }
    public string PokemonName { get; set; }
    public bool? IsAlive { get; set; }
    public bool IsBattle { get; set; }
    public int RunBattleId { get; set; }
    public bool BattleCompleted { get; set; }
}
