using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuzlockeSoulLinkClassLibrary.DataAccess;

public class SqlAccess : ISqlAccess
{
    private readonly IConfiguration _config;
    public string ConnectionStringName { get; set; } = "Default";
    public SqlAccess(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Loads data from a stored proc
    /// </summary>
    /// <typeparam name="T">Returned object type</typeparam>
    /// <typeparam name="U">Parameters type</typeparam>
    /// <param name="sql">Stored proc string</param>
    /// <param name="parameters">Stored proc parameters</param>
    /// <returns>A list of T objects</returns>
    public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);

            return data.ToList();
        }
    }

    /// <summary>
    /// Loads data from a stored proc, and allows for nested lists of objects within objects
    /// </summary>
    /// <typeparam name="T">Returned object type</typeparam>
    /// <typeparam name="U">Nested object type</typeparam>
    /// <typeparam name="V">Parameters type</typeparam>
    /// <param name="sql">Stored proc string</param>
    /// <param name="parameters">Stored proc parameters</param>
    /// <param name="lambda">The function used to map the nested object</param>
    /// <param name="splitOn">Where the returned data is split for the nested object</param>
    /// <returns>A list of T objects</returns>
    public async Task<List<T>> LoadNestedData<T, U, V>(string sql, V parameters, Func<T, U, T> lambda, string splitOn)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var data = await connection.QueryAsync<T, U, T>(sql, lambda, parameters, splitOn: splitOn, commandType: CommandType.StoredProcedure);

            return data.ToList();
        }
    }

    /// <summary>
    /// Saves data to the db using a stored proc
    /// </summary>
    /// <typeparam name="T">Parameters type</typeparam>
    /// <param name="sql">Stored proc string</param>
    /// <param name="parameters">Stored proc parameters</param>
    /// <returns></returns>
    public async Task SaveData<T>(string sql, T parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
