using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class CreateRunsData
{
    private readonly ISqlAccess _db;
    public CreateRunsData(ISqlAccess db)
    {
        _db = db;
    }

    public async Task<List<GenerationModel>> GetGenerations()
    {
        string sql = "spGetGenerations";

        return await _db.LoadData<GenerationModel, dynamic>(sql, new { });
    }

    public async Task<List<GameModel>> GetGames()
    {
        string sql = "spGetGames";

        return await _db.LoadData<GameModel, dynamic>(sql, new { });
    }

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

    public async Task<bool> CheckDuplicateName(string runName)
    {
        var run = await GetRunByName(runName);

        if (run != null)
        {
            return true;
        }
        return false;
    }

    public async Task<int> CreateNewRun(RunModel run)
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

        var createdRun = await _db.LoadData<int, dynamic>(sql, parameters);

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
