using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary
{
    public class PokemonData
    {
        private readonly ISqlAccess _db;
        public PokemonData(ISqlAccess db)
        {
            _db = db;
        }

        public Task<List<PokemonModel>> GetPokemon()
        {
            //TODO: Sql code goes here, in the form of stored proc calls
            string sql = "";

            return _db.LoadData<PokemonModel, dynamic>(sql, new { });
        }

        public Task InsertPokemon(PokemonModel pokemon)
        {
            //TODO: For adding new entries to the db, stored procs again, not needed for pokemon tho, here as a placeholder
            string sql = "";

            return _db.SaveData(sql, pokemon);
        }
    }
}
