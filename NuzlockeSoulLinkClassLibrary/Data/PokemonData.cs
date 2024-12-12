using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

/// <summary>
/// Handles requests for Pokemon data from the database 
/// </summary>
public class PokemonData
{
    private readonly ISqlAccess _db;
    public PokemonData(ISqlAccess db)
    {
        _db = db;
    }

    /// <summary>
    /// Gets all pokemon from the DB
    /// </summary>
    /// <returns>A list of all Pokemon in the db</returns>
    public async Task<List<PokemonModel>> GetPokemon()
    {
        string sql = "spGetPokemon";

        var pokemon = await _db.LoadData<PokemonModel, dynamic>(sql, new { });

        return pokemon.ToList();
    }

    /// <summary>
    /// Gets the pokemon sprite from PokeApi
    /// </summary>
    /// <param name="dexNum">A Pokemons dex number</param>
    /// <returns>An Image string, with a 1/100 chance of being shiny</returns>
    public async Task<string> GetPokemonImage(int dexNum)
    {
        Random rand = new Random();
        if (rand.Next(1, 101) == 100)
        {
            return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/{dexNum}.png";
        }
        return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{dexNum}.png";
    }
}
