using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class BattlesModel
    {
        public int BattleId { get; set; }
        public int GameId { get; set; }
        public string BattleName { get; set; }
        public string BattleLocation { get; set; }
        public string PokemonUsed { get; set; }
        public int HighestLevel { get; set; }
        public int ProgressionOrder { get; set; }
        public string ImageLink { get; set; }
    }
}
