using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

public class RouteModel : IProgressionOrderable, IEquatable<RouteModel>
{
    public int RouteId { get; set; }
    public int GameId { get; set; }
    public string RouteName { get; set; }
    public int ProgressionOrder { get; set; }

    public bool Equals(RouteModel other)
    {
        if (other == null)
            return false;

        if (this.RouteId == other.RouteId && this.GameId == other.GameId &&
            this.RouteName == other.RouteName && this.ProgressionOrder == other.ProgressionOrder)
            return true;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RouteId, GameId, RouteName, ProgressionOrder);
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        RouteModel routeObj = obj as RouteModel;
        if (routeObj == null)
            return false;
        return Equals(routeObj);
    }
}
