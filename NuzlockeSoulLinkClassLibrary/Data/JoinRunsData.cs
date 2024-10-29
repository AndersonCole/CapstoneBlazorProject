using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        string splitOn = "run_player_id";

        var parameters = new
        {
            id = runId
        };

        Func<RunModel, RunPlayerModel, RunModel> lambda = (run, run_player) =>
        {
            run.RunPlayers.Add(run_player);
            return run;
        };

        var run = await _db.LoadNestedData<RunModel, RunPlayerModel, dynamic>(sql, parameters, lambda, splitOn);

        var result = run.GroupBy(r => r.RunId).Select(g =>
        {
            var groupedRun = g.First();
            groupedRun.RunPlayers = g.Select(r => r.RunPlayers.Single()).ToList();
            return groupedRun;
        }).ToList();

        return result.FirstOrDefault();
    }

    public async Task<string> JoinRun(RunModel run, string runPassword, int playerId)
    {
        if (run.HasOpenSlots)
        {
            bool passwordMatch = VerifyPassword(runPassword, run.RunPassword);

            if (passwordMatch)
            {
                string sql = "spJoinRun";

                var parameters = new
                {
                    playerId,
                    runId = run.RunId
                };

                await _db.SaveData<dynamic>(sql, parameters);

                return "Success";
            }
            return "Password does not match!";
        }
        return "Run is full! Please try joining a different run!";
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
