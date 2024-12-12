using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Class for managing access to db data for the admin pages
/// </summary>
public class AdminData
{
    private readonly ISqlAccess _db;
    public AdminData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets all generations
    /// </summary>
    /// <returns>A list of Generation Model</returns>
    public async Task<List<GenerationModel>> GetGenerations()
    {
        string sql = "spGetGenerations";

        return await _db.LoadData<GenerationModel, dynamic>(sql, new { });
    }

    /// <summary>
    /// Gets all games
    /// </summary>
    /// <returns>A list of games</returns>
    public async Task<List<GameModel>> GetGames()
    {
        string sql = "spGetGames";

        return await _db.LoadData<GameModel, dynamic>(sql, new { });
    }

    /// <summary>
    /// Gets all games and routes in a game, then combines them into one List ordered by ProgressionOrder
    /// </summary>
    /// <param name="gameId">Id of the game</param>
    /// <returns></returns>
    public async Task<List<AdminGameStepModel>> GetOrderedGameProgression(int? gameId)
    {
        var gameRoutes = await GetGameRoutes(gameId);
        var gameBattles = await GetGameBattles(gameId);

        List<AdminGameStepModel> combinedProgression = gameRoutes.Select(r => new AdminGameStepModel {
                                                                                             ProgressionStep = r,
                                                                                             IsRoute = true,
                                                                                             IsBattle = false
                                                                                         })
                                                            .Concat(gameBattles.Select(b => new AdminGameStepModel {
                                                                                                                    ProgressionStep = b,
                                                                                                                    IsRoute = false,
                                                                                                                    IsBattle = true
                                                                                                              }))
                                                            .OrderBy(step => step.ProgressionStep.ProgressionOrder)
                                                            .ToList();
        return combinedProgression;
    }

    /// <summary>
    /// Gets all routes from a game
    /// </summary>
    /// <param name="gameId"></param>
    /// <returns>A list of Route Models</returns>
    private async Task<List<RouteModel>> GetGameRoutes(int? gameId)
    {
        string sql = "spGetRoutesFromGameId";

        var parameters = new
        {
            gameId
        };

        var routes = await _db.LoadData<RouteModel, dynamic>(sql, parameters);

        return routes;
    }

    /// <summary>
    /// Gets all battles from a game
    /// </summary>
    /// <param name="gameId"></param>
    /// <returns>A list of battle models</returns>
    private async Task<List<BattleModel>> GetGameBattles(int? gameId)
    {
        string sql = "spGetBattlesFromGameId";

        var parameters = new
        {
            gameId
        };

        var battles = await _db.LoadData<BattleModel, dynamic>(sql, parameters);

        return battles;
    }

    /// <summary>
    /// Inserts a new route into the database
    /// </summary>
    /// <param name="newRoute">The model containing all route details</param>
    /// <returns></returns>
    public async Task CreateRoute(RouteModel newRoute)
    {
        string sql = "spCreateNewRoute";

        var parameters = new
        {
            newRoute.GameId,
            Name = newRoute.RouteName,
            Order = newRoute.ProgressionOrder
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Inserts a new battle into the db
    /// </summary>
    /// <param name="newBattle">The model containing all battle details</param>
    /// <returns></returns>
    public async Task CreateBattle(BattleModel newBattle)
    {
        string sql = "spCreateNewBattle";

        var parameters = new
        {
            newBattle.GameId,
            Name = newBattle.BattleName,
            Location = newBattle.BattleLocation,
            newBattle.PokemonUsed,
            newBattle.HighestLevel,
            newBattle.ImageLink,
            Order = newBattle.ProgressionOrder
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Updates a route already in the db
    /// </summary>
    /// <param name="route">The model containing all route details</param>
    /// <returns></returns>
    public async Task ModifyRoute(RouteModel route)
    {
        string sql = "spModifyRoute";

        var parameters = new
        {
            route.RouteId,
            Name = route.RouteName,
            Order = route.ProgressionOrder
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Updates a battle already in the db
    /// </summary>
    /// <param name="battle">The model containing all battle info</param>
    /// <returns></returns>
    public async Task ModifyBattle(BattleModel battle)
    {
        string sql = "spModifyBattle";

        var parameters = new
        {
            battle.BattleId,
            Name = battle.BattleName,
            Location = battle.BattleLocation,
            battle.PokemonUsed,
            battle.HighestLevel,
            battle.ImageLink,
            Order = battle.ProgressionOrder
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Deletes a route from the db
    /// </summary>
    /// <param name="routeId">Id of the route to be deleted</param>
    /// <returns></returns>
    public async Task DeleteRoute(int routeId)
    {
        string sql = "spDeleteRoute";

        var parameters = new
        {
            routeId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Deletes a battle from the db
    /// </summary>
    /// <param name="battleId">Id of the battle to be deleted</param>
    /// <returns></returns>
    public async Task DeleteBattle(int battleId)
    {
        string sql = "spDeleteBattle";

        var parameters = new
        {
            battleId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Gets all games based on the genId
    /// </summary>
    /// <param name="genId"></param>
    /// <returns>A list of admin game models</returns>
    public async Task<List<AdminGameModel>> GetGamesFromGen(int? genId)
    {
        string sql = "spGetGamesFromGenId";

        var parameters = new
        {
            genId
        };

        var games = await _db.LoadData<GameModel, dynamic>(sql, parameters);

        List<AdminGameModel> adminGames = games.Select(g => new AdminGameModel {
                                                                            Game = g
                                                                        }).ToList();
        return adminGames;
    }

    /// <summary>
    /// Adds a new game into the db
    /// </summary>
    /// <param name="newGame">The model containing all game info</param>
    /// <returns></returns>
    public async Task CreateGame(GameModel newGame)
    {
        string sql = "spCreateNewGame";

        var parameters = new
        {
            newGame.GenId,
            Name = newGame.GameName,
            newGame.Abbreviation,
            newGame.Region
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Modifies an already existing game in the db
    /// </summary>
    /// <param name="game">The model containing all game info</param>
    /// <returns></returns>
    public async Task ModifyGame(GameModel game)
    {
        string sql = "spModifyGame";

        var parameters = new
        {
            game.GameId,
            Name = game.GameName,
            game.Abbreviation,
            game.Region
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Deletes a game from the db
    /// </summary>
    /// <param name="gameId">Id of the game to be deleted</param>
    /// <returns></returns>
    public async Task DeleteGame(int gameId)
    {
        string sql = "spDeleteGame";

        var parameters = new
        {
            gameId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Gets all gens
    /// </summary>
    /// <returns>A list of admin gen models</returns>
    public async Task<List<AdminGenModel>> GetAdminGens()
    {
        string sql = "spGetGenerations";

        var gens = await _db.LoadData<GenerationModel, dynamic>(sql, new { });

        List<AdminGenModel> adminGens = gens.Select(g => new AdminGenModel
        {
            Gen = g
        }).ToList();
        return adminGens;
    }

    /// <summary>
    /// Adds a new gen to the db
    /// </summary>
    /// <param name="newGen">The model containing all info on the new gen</param>
    /// <returns></returns>
    public async Task CreateGen(GenerationModel newGen)
    {
        string sql = "spCreateNewGen";

        var parameters = new
        {
            newGen.RomanNumeral
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Updates an existing gen in the db
    /// </summary>
    /// <param name="gen">The model containing all info on the gen</param>
    /// <returns></returns>
    public async Task ModifyGen(GenerationModel gen)
    {
        string sql = "spModifyGen";

        var parameters = new
        {
            gen.GenId,
            gen.RomanNumeral
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    /// <summary>
    /// Deletes a gen from the db
    /// </summary>
    /// <param name="genId">Id of the gen to be deleted</param>
    /// <returns></returns>
    public async Task DeleteGen(int genId)
    {
        string sql = "spDeleteGen";

        var parameters = new
        {
            genId
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }
}
