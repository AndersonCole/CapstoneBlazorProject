using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class LeaderboardData
{
    private readonly ISqlAccess _db;
    public LeaderboardData(ISqlAccess db)
    {
        _db = db;
    }

    public async Task<List<LeaderboardModel>> GetLeaderboardUsers()
    {
        string sql = "spGetLeaderboardUsers";

        return await _db.LoadData<LeaderboardModel, dynamic>(sql, new { });
    }
}
