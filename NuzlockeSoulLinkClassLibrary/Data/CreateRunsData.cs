using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing access to db data for the create run page
/// </summary>
public class CreateRunsData
{
    private readonly ISqlAccess _db;
    public CreateRunsData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets all generations
    /// </summary>
    /// <returns>A list of generation models</returns>
    public async Task<List<GenerationModel>> GetGenerations()
    {
        string sql = "spGetGenerations";

        return await _db.LoadData<GenerationModel, dynamic>(sql, new { });
    }

    /// <summary>
    /// gets all games
    /// </summary>
    /// <returns>A list of game model</returns>
    public async Task<List<GameModel>> GetGames()
    {
        string sql = "spGetGames";

        return await _db.LoadData<GameModel, dynamic>(sql, new { });
    }

    /// <summary>
    /// Gets a run by its name
    /// </summary>
    /// <param name="runName">The name of the run to get</param>
    /// <returns>A RunModel</returns>
    public async Task<RunModel> GetRunByName(string runName)
    {
        string sql = "spGetRunFromName";

        var parameters = new
        {
            name = runName
        };

        var run = await _db.LoadData<RunModel, dynamic>(sql, parameters);

        return run.FirstOrDefault();
    }

    /// <summary>
    /// Checks if the name of a run is unique
    /// </summary>
    /// <param name="runName">The name of the run to check</param>
    /// <returns>True if the run name is used, false if its unused</returns>
    public async Task<bool> CheckDuplicateName(string runName)
    {
        var run = await GetRunByName(runName);

        if (run != null)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a new run, and returns its id
    /// </summary>
    /// <param name="run">Details about the run to creates</param>
    /// <returns>The run id GUID</returns>
    public async Task<Guid> CreateNewRun(RunModel run)
    {
        string sql = "spCreateAndReturnRun";

        var password = HashPassword(run.RunPassword);

        var parameters = new
        {
            run.RunName,
            run.RunDescription,
            password,
            run.RunCreatorId,
            run.MaxPlayers,
            run.GameId,
            run.CreatedDate,
            run.LastUpdated
        };

        var createdRun = await _db.LoadData<Guid, dynamic>(sql, parameters);

        return createdRun.FirstOrDefault();
    }

    /// <summary>
    /// Hashes the password using BCrypt
    /// </summary>
    /// <param name="password">The password entered at registration</param>
    /// <returns></returns>
    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
}
