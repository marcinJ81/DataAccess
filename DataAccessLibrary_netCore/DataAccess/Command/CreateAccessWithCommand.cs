using Dapper;
using DataAccessLibrary_netCore.ConString;
using DataAccessLibrary_netCore.DataAccess.Query;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataAccess.Command
{
    public class CreateAccessWithCommand : ICreateAccessWithCommand
    {
        private string constring { get; set; }
        public CreateAccessWithCommand(IConnectStringAccess connectionStringAccess)
        {
            constring = connectionStringAccess.GetConString;
        }

        public async Task Async_SaveData<T, U>(string sql, U parameters, dbType db_Type)
        {
            if (db_Type == dbType.mssql)
            {
                using (IDbConnection connection = new SqlConnection(constring))
                {
                    await connection.ExecuteAsync(sql, parameters);
                    return;
                }
            }
            using (IDbConnection connection = new SqliteConnection(constring))
            {
                await connection.ExecuteAsync(sql, parameters);
            }

        }

        public void Sync_SaveData<T,U>(string sql, U parameters, dbType db_Type)
        {
            if (db_Type == dbType.mssql)
            {
                using (IDbConnection connection = new SqlConnection(constring))
                {
                    connection.Execute(sql, parameters);
                }
            }
            using (IDbConnection connection = new SqliteConnection(constring))
            {
                connection.Execute(sql, parameters);

            }
        }

    }
}
