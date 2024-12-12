using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing access to db data for the ongoing run page
/// </summary>
public class OngoingRunsData
{
    private readonly ISqlAccess _db;
    public OngoingRunsData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets all details about a run, with all nested objects
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns>A run model</returns>
    public async Task<RunModel> GetFullRunDetailsFromId(Guid runId)
    {
        string sql = "spGetRunFromId";

        var parameters = new
        {
            runId
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

    /// <summary>
    /// Gets run players
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns>A list of run player models</returns>
    public async Task<List<RunPlayerModel>> GetRunPlayers(Guid runId)
    {
        string sql = "spGetPlayersFromRunId";

        var parameters = new
        {
            runId
        };

        var players = await _db.LoadData<RunPlayerModel, dynamic>(sql, parameters);

        return players;
    }

    /// <summary>
    /// Gets run battles
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns>A list of run battle models</returns>
    public async Task<List<RunBattleModel>> GetRunBattles(Guid runId)
    {
        string sql = "spGetBattlesFromRunId";

        string splitOn = "battle_id";

        var parameters = new
        {
            runId
        };

        //gets nested battle model data
        Func<RunBattleModel, BattleModel, RunBattleModel> lambda = (runBattle, battle) =>
        {
            runBattle.Battle = battle;
            return runBattle;
        };

        var battles = await _db.LoadNestedData<RunBattleModel, BattleModel, dynamic>(sql, parameters, lambda, splitOn);

        return battles;
    }

    /// <summary>
    /// Gets run encounters
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns>List of run encounters</returns>
    public async Task<List<RunEncounterModel>> GetRunEncounters(Guid runId)
    {
        string sql = "spGetEncountersFromRunId";

        string splitOn = "route_id";

        var parameters = new
        {
            runId
        };

        //gets nested route model data
        Func<RunEncounterModel, RouteModel, RunEncounterModel> lambda = (runEncounter, route) =>
        {
            runEncounter.Route = route;
            return runEncounter;
        };

        var encounters = await _db.LoadNestedData<RunEncounterModel, RouteModel, dynamic>(sql, parameters, lambda, splitOn);

        return encounters;
    }

    /// <summary>
    /// Gets run messages
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns>A list of run messages</returns>
    public async Task<List<RunChatModel>> GetRunMessages(Guid runId)
    {
        string sql = "spGetMessagesFromRunId";

        var parameters = new
        {
            runId
        };

        var messages = await _db.LoadData<RunChatModel, dynamic>(sql, parameters);

        return messages;
    }

    /// <summary>
    /// Gets all pokemon
    /// </summary>
    /// <returns>A list of all pokemon</returns>
    public async Task<List<PokemonModel>> GetPokemon()
    {
        string sql = "spGetPokemon";

        var pokemon = await _db.LoadData<PokemonModel, dynamic>(sql, new { });

        return pokemon.ToList();
    }

    /// <summary>
    /// Saves encounter data after a user updates it
    /// </summary>
    /// <param name="runEncounterId">Run Encounter Id</param>
    /// <param name="dexNum">dex number of the pokemon</param>
    /// <param name="isAlive">0,1,2 int for not encountered, alive and dead</param>
    /// <returns></returns>
    public async Task SaveEncounterData(int runEncounterId, int? dexNum, int isAlive)
    {
        string sql = "spUpdateEncounter";

        var parameters = new
        {
            runEncounterId,
            dexNum,
            isAlive
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Saves battle data after a user changes it
    /// </summary>
    /// <param name="runBattleId">Run battle id</param>
    /// <param name="isComplete">whether the battle was completed or not</param>
    /// <returns></returns>
    public async Task SaveBattleData(int runBattleId, bool? isComplete)
    {
        string sql = "spUpdateBattle";

        var parameters = new
        {
            runBattleId,
            isComplete
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Sends a message to the run chat
    /// </summary>
    /// <param name="runPlayerId">Run player id</param>
    /// <param name="chatMessage">The message content</param>
    /// <returns></returns>
    public async Task SendRunMessage(int runPlayerId, string chatMessage)
    {
        string sql = "spSendMessage";

        var parameters = new
        {
            runPlayerId,
            chatMessage,
            TimeSent = DateTimeOffset.Now
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Marks the run as completed
    /// </summary>
    /// <param name="runId">Id of the run</param>
    /// <returns></returns>
    public async Task CompleteRun(Guid runId)
    {
        string sql = "spCompleteRun";

        var parameters = new
        {
            runId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Updates the players win count when a run is successfully completed
    /// </summary>
    /// <param name="runPlayerId"></param>
    /// <returns></returns>
    public async Task UpdatePlayerCompletions(int runPlayerId)
    {
        string sql = "spUpdateWins";

        var parameters = new
        {
            runPlayerId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }
}
