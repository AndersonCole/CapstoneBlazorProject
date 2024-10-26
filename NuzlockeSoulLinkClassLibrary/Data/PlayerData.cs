﻿using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class PlayerData
{
    private readonly ISqlAccess _db;
    public PlayerData(ISqlAccess db)
    {
        _db = db;
    }

    public async Task<PlayerModel> GetPlayerByUsername(string username)
    {
        string sql = "spGetPlayerFromUsername";

        var parameters = new
        {
            username
        };

        var player = await _db.LoadData<PlayerModel, dynamic>(sql, parameters);

        return player.FirstOrDefault();
    }

    public async Task<bool> CheckDuplicateUsername(string username)
    {
        var player = await GetPlayerByUsername(username);

        if (player != null)
        {
            return true;
        }
        return false;
    }

    public async Task<PlayerModel> RegisterNewPlayer(PlayerModel player)
    {
        string sql = "spRegisterPlayer";

        var password = HashPassword(player.Password);

        var parameters = new
        {
            player.Username,
            password,
            player.CreatedDate
        };

        await _db.SaveData(sql, parameters);

        return await GetPlayerByUsername(player.Username);
    }

    public async Task<PlayerModel> LoginReturningPlayer(string username, string password)
    {
        var player = await GetPlayerByUsername(username);

        if (player != null)
        {
            bool passwordMatch = VerifyPassword(password, player.Password);

            if (passwordMatch)
            {
                return player;
            }
        }
        return null;
    }

    // TODO: Testing data, DELETE THIS!!!
    //public async Task<List<RunBattleModel>> GetRunBattles(int runId)
    //{
    //    string sql = "spGetBattlesFromRunId";

    //    string splitOn = "battle_id";

    //    var parameters = new
    //    {
    //        id = runId
    //    };

    //    Func<RunBattleModel, BattleModel, RunBattleModel> lambda = (runBattle, battle) =>
    //    {
    //        runBattle.Battle = battle;
    //        return runBattle;
    //    };

    //    var players = await _db.LoadNestedData<RunBattleModel, BattleModel, dynamic>(sql, parameters, lambda, splitOn);

    //    return players;
    //}

    /// <summary>
    /// Hashes the password using BCrypt
    /// </summary>
    /// <param name="password">The password entered at registration</param>
    /// <returns></returns>
    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
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
