using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Model representing a route, which is any location where a pokemon can be encountered, extends IProgressionOrderable so it can be sorted with Battle models
/// </summary>
public class RouteModel : IProgressionOrderable, IEquatable<RouteModel>
{
    /// <summary>
    /// Id of the route
    /// </summary>
    public int RouteId { get; set; }
    /// <summary>
    /// Id of the game the route appears in
    /// </summary>
    public int GameId { get; set; }
    /// <summary>
    /// Name of the route
    /// </summary>
    public string RouteName { get; set; }
    /// <summary>
    /// Order the route appears in progression, higher number = later in progression
    /// </summary>
    public int ProgressionOrder { get; set; }

    /// <summary>
    /// Functions for equality
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
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
