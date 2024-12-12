using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing access to db data for the nav sidebar
/// </summary>
public class NavMenuData
{
    private readonly ISqlAccess _db;
    public NavMenuData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets any runs a player is in, for quick access in the nav menu
    /// </summary>
    /// <param name="playerId">Id of the player</param>
    /// <returns></returns>
    public async Task<List<RunModel>> GetRunsFromPlayerId(int playerId)
    {
        string sql = "spGetRunsFromPlayerId";

        var parameters = new
        {
            playerId
        };

        return await _db.LoadData<RunModel, dynamic>(sql, parameters);
    }
}
