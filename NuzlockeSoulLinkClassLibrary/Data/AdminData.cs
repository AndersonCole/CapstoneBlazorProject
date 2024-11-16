using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class AdminData
{
    private readonly ISqlAccess _db;
    public AdminData(ISqlAccess db)
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

    private async Task<List<RouteModel>> GetGameRoutes(int? gameId)
    {
        string sql = "spGetRoutesFromGameId";

        var parameters = new
        {
            id = gameId
        };

        var routes = await _db.LoadData<RouteModel, dynamic>(sql, parameters);

        return routes;
    }

    private async Task<List<BattleModel>> GetGameBattles(int? gameId)
    {
        string sql = "spGetBattlesFromGameId";

        var parameters = new
        {
            id = gameId
        };

        var battles = await _db.LoadData<BattleModel, dynamic>(sql, parameters);

        return battles;
    }

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

    public async Task DeleteRoute(int id)
    {
        string sql = "spDeleteRoute";

        var parameters = new
        {
            RouteId = id
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    public async Task DeleteBattle(int id)
    {
        string sql = "spDeleteBattle";

        var parameters = new
        {
            BattleId = id
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

    public async Task<List<AdminGameModel>> GetGamesFromGen(int? genId)
    {
        string sql = "spGetGamesFromGenId";

        var parameters = new
        {
            id = genId
        };

        var games = await _db.LoadData<GameModel, dynamic>(sql, parameters);

        List<AdminGameModel> adminGames = games.Select(g => new AdminGameModel {
                                                                            Game = g
                                                                        }).ToList();
        return adminGames;
    }

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

    public async Task DeleteGame(int id)
    {
        string sql = "spDeleteGame";

        var parameters = new
        {
            GameId = id
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

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

    public async Task CreateGen(GenerationModel newGen)
    {
        string sql = "spCreateNewGen";

        var parameters = new
        {
            newGen.RomanNumeral
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }

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

    public async Task DeleteGen(int id)
    {
        string sql = "spDeleteGen";

        var parameters = new
        {
            GenId = id
        };

        await _db.SaveData<dynamic>(sql, parameters);
    }
}
