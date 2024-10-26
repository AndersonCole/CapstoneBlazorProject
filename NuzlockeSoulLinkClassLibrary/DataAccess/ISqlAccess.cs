namespace NuzlockeSoulLinkClassLibrary.DataAccess;

public interface ISqlAccess
{
    string ConnectionStringName { get; set; }

    Task<List<T>> LoadData<T, U>(string sql, U parameters);
    Task<List<T>> LoadNestedData<T, U, V>(string sql, V parameters, Func<T, U, T> lambda, string splitOn);
    Task SaveData<T>(string sql, T parameters);
}