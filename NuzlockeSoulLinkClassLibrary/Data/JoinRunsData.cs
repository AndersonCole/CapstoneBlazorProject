using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class JoinRunsData
{
    private readonly ISqlAccess _db;
    public JoinRunsData(ISqlAccess db)
    {
        _db = db;
    }

    public async Task<RunModel> GetRunFromId(int runId)
    {
        string sql = "spGetRunFromId";

        var parameters = new
        {
            id = runId
        };

        var run = await _db.LoadData<RunModel, dynamic>(sql, parameters);

        return run.FirstOrDefault();
    }

    /// <summary>
    /// Attempts to verify the password a user entered to the stored hased password
    /// </summary>
    /// <param name="enteredPassword">The password entered at login</param>
    /// <param name="passwordHash">The password hash stored in the db</param>
    /// <returns></returns>
    private static bool VerifyPassword(string enteredPassword, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(enteredPassword, passwordHash);
    }
}
