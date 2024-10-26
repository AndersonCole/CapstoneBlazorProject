using NuzlockeSoulLinkClassLibrary.DataAccess;
using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.Data;

public class PokemonData
{
    private readonly ISqlAccess _db;
    public PokemonData(ISqlAccess db)
    {
        _db = db;
    }

    public Task<List<PokemonModel>> GetPokemon()
    {
        //TODO: Make pokemon stuff
        string sql = "";

        return _db.LoadData<PokemonModel, dynamic>(sql, new { });
    }
}
