using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class RunBattleModel
    {
        public int RunBattleId { get; set; }
        public int RunPlayerId { get; set; }
        public int BattleId { get; set; }
        //override for the regular battles class, to be used in cases like randomizers where the battles are different
        public string PokemonUsed { get; set; }
        public bool BattleCompleted { get; set; }
    }
}
