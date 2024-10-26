using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RouteModel : IProgressionOrderable
{
    public int RouteId { get; set; }
    public int GameId { get; set; }
    public int ProgressionOrder { get; set; }
    public string RouteName { get; set; }
}
