using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RunEncounterModel
{
    public int EncounterId { get; set; }
    public int RunPlayerId { get; set; }
    public RouteModel Route { get; set; }
    public int DexNumber { get; set; }
}
