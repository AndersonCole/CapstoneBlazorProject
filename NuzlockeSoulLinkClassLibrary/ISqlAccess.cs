﻿
namespace NuzlockeSoulLinkClassLibrary
{
    public interface ISqlAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}