using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class OngoingRunsData
{
    private readonly ISqlAccess _db;
    public OngoingRunsData(ISqlAccess db)
    {
        _db = db;
    }

    public async Task<RunModel> GetFullRunDetailsFromId(int runId)
    {
        string sql = "spGetRunFromId";

        var parameters = new
        {
            id = runId
        };

        var run = await _db.LoadData<RunModel, dynamic>(sql, parameters);

        var selectedRun = run.FirstOrDefault();

        if(selectedRun == null)
            return new RunModel();

        selectedRun.RunPlayers = await GetRunPlayers(runId);

        selectedRun.RunBattles = await GetRunBattles(runId);

        selectedRun.RunEncounters = await GetRunEncounters(runId);

        selectedRun.RunChatMessages = await GetRunMessages(runId);

        return selectedRun;
    }

    public async Task<List<RunPlayerModel>> GetRunPlayers(int runId)
    {
        string sql = "spGetPlayersFromRunId";

        var parameters = new
        {
            id = runId
        };

        var players = await _db.LoadData<RunPlayerModel, dynamic>(sql, parameters);

        return players;
    }

    public async Task<List<RunBattleModel>> GetRunBattles(int runId)
    {
        string sql = "spGetBattlesFromRunId";

        string splitOn = "battle_id";

        var parameters = new
        {
            id = runId
        };

        Func<RunBattleModel, BattleModel, RunBattleModel> lambda = (runBattle, battle) =>
        {
            runBattle.Battle = battle;
            return runBattle;
        };

        var battles = await _db.LoadNestedData<RunBattleModel, BattleModel, dynamic>(sql, parameters, lambda, splitOn);

        return battles;
    }

    public async Task<List<RunEncounterModel>> GetRunEncounters(int runId)
    {
        string sql = "spGetEncountersFromRunId";

        string splitOn = "route_id";

        var parameters = new
        {
            id = runId
        };

        Func<RunEncounterModel, RouteModel, RunEncounterModel> lambda = (runEncounter, route) =>
        {
            runEncounter.Route = route;
            return runEncounter;
        };

        var encounters = await _db.LoadNestedData<RunEncounterModel, RouteModel, dynamic>(sql, parameters, lambda, splitOn);

        return encounters;
    }

    public async Task<List<RunChatModel>> GetRunMessages(int runId)
    {
        string sql = "spGetMessagesFromRunId";

        var parameters = new
        {
            id = runId
        };

        var messages = await _db.LoadData<RunChatModel, dynamic>(sql, parameters);

        return messages;
    }
}
