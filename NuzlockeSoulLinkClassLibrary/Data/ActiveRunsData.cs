using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing access to db data for the active runs page
/// </summary>
public class ActiveRunsData
{
    private readonly ISqlAccess _db;
    public ActiveRunsData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets all generations from the db
    /// </summary>
    /// <returns>List of </returns>
    public async Task<List<GenerationModel>> GetGenerations()
    {
        string sql = "spGetGenerations";

        return await _db.LoadData<GenerationModel, dynamic>(sql, new { });
    }

    /// <summary>
    /// Gets all runs that haven't been completed yet
    /// </summary>
    /// <returns>A list of run models</returns>
    public async Task<List<RunModel>> GetOngoingRuns()
    {
        string sql = "spGetOngoingRuns";

        string splitOn = "run_player_id";

        //loads a list of run player models into the runModel
        Func<RunModel, RunPlayerModel, RunModel> lambda = (run, run_player) =>
        {
            run.RunPlayers.Add(run_player);
            return run;
        };

        var runs = await _db.LoadNestedData<RunModel, RunPlayerModel, dynamic>(sql, new { }, lambda, splitOn);

        var results = runs.GroupBy(r => r.RunId).Select(g =>
        {
            var groupedRun = g.First();
            groupedRun.RunPlayers = g.Select(r => r.RunPlayers.Single()).ToList();
            return groupedRun;
        }).ToList();

        return results;
    }

    /// <summary>
    /// Gets all runs in the specified gen that haven't been completed yet
    /// </summary>
    /// <param name="genId">Generation Id</param>
    /// <returns>A list of run models</returns>
    public async Task<List<RunModel>> GetOngoingRunsByGen(int genId)
    {
        string sql = "spGetOngoingRunsByGen";

        string splitOn = "run_player_id";

        var parameters = new
        {
            genId
        };

        //loads a list of run player models into the runModel
        Func<RunModel, RunPlayerModel, RunModel> lambda = (run, run_player) =>
        {
            run.RunPlayers.Add(run_player);
            return run;
        };

        var runs = await _db.LoadNestedData<RunModel, RunPlayerModel, dynamic>(sql, parameters, lambda, splitOn);

        var results = runs.GroupBy(r => r.RunId).Select(g =>
        {
            var groupedRun = g.First();
            groupedRun.RunPlayers = g.Select(r => r.RunPlayers.Single()).ToList();
            return groupedRun;
        }).ToList();

        return results;
    }
}
