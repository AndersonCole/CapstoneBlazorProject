using NuzlockeSoulLinkClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary
{
    public class ActiveRunsData
    {
        private readonly ISqlAccess _db;
        public ActiveRunsData(ISqlAccess db)
        {
            _db = db;
        }

        public async Task<List<GenerationModel>> GetGenerations()
        {
            string sql = "spGetGenerations";

            return await _db.LoadData<GenerationModel, dynamic>(sql, new { });
        }

        public async Task<List<RunModel>> GetOngoingRuns()
        {
            string sql = "spGetOngoingRuns";

            return await _db.LoadData<RunModel, dynamic>(sql, new { });
        }

        public async Task<List<RunModel>> GetOngoingRunsByGen(int genId)
        {
            string sql = "spGetOngoingRunsByGen";

            var parameters = new
            {
                genId
            };

            return await _db.LoadData<RunModel, dynamic>(sql, parameters);
        }
    }
}
