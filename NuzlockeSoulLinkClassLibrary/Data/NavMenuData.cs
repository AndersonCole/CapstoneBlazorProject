using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class NavMenuData
{
    private readonly ISqlAccess _db;
    public NavMenuData(ISqlAccess db)
    {
        _db = db;
    }

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
