using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary_netCore.ConString;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary_netCore.DataAccess.Query
{
    public enum dbType
    { 
       mssql,
       sqlite
    }
    public class SQLDataAccessQuery : ISQLDataAccessQuery
    {
        private string constring { get; set; }
        //private IDbConnection connectionToMSSQL; //do wykorzystania w tym miejsu zamiast ifa
        //private IDbConnection connectionToSQLite;

        public SQLDataAccessQuery(IConnectStringAccess connectionStringAccess )
        {
            constring = connectionStringAccess.GetConString;
        }

        public async Task<List<T>> loadData_async<T, U>(string sql, U parameters,dbType db_Type)
        {
            if (db_Type == dbType.mssql )
            {
                using (IDbConnection connection = new SqlConnection(constring))
                {
                    var data = await connection.QueryAsync<T>(sql, parameters);

                    return data.AsList();
                }
            }
            using (IDbConnection connection = new SqliteConnection(constring))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.AsList();
            }

        }
        List<T> ISQLDataAccessQuery.loadData_sync<T, U>(string sql, U parameters, dbType db_Type)
        {
            if (db_Type == dbType.mssql)
            {
                using (IDbConnection connection = new SqlConnection(constring))
                {
                    var data = connection.Query<T>(sql, parameters);

                    return data.AsList();
                }
            }
            using (IDbConnection connection = new SqliteConnection(constring))
            {
                var data = connection.Query<T>(sql, parameters);
                return data.AsList();
            }
        }
    }
}
