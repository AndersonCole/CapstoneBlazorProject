using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models
{
    public class PokemonModel
    {
        public int DexNumber { get; set; }
        public string PokemonName { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public int EvolvesFrom { get; set; }
        public string EvolvesInto { get; set; }
    }
}
