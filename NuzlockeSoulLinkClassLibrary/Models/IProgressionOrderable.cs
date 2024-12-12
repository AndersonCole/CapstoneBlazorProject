using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Models;

/// <summary>
/// Interface for routes and battles, lets them be sorted at the same time for sequential progression order 
/// </summary>
public interface IProgressionOrderable
{
    /// <summary>
    /// Order the routes and battles take in a run
    /// </summary>
    int ProgressionOrder { get; set; }
}
