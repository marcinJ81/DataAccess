using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLibrary2.ConString
{
    
    public class ConnectStringAccess : IConnectStringAccess
    {
        private string ConnectionStringName { get; set; }
        public string GetConString => (string)ConnectionStringName;
       
        public ConnectStringAccess(IConfiguration config, string connectionType)
        {
            string conTypes = SConnectionStringTypes.getdictionaryTypes.Where(x => x.Key == connectionType).FirstOrDefault().Value;
            ConnectionStringName = config.GetConnectionString(conTypes);
        }
        public ConnectStringAccess(string tableNameSqlite)
        {
            string tablename = "";
            string pathDbFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!STableNameDictionary.getdTableName.Any(x => x.Key == tableNameSqlite))
            {
                tablename = STableNameDictionary.getdTableName.Where(x => x.Key == "Client").FirstOrDefault().Value;
            }
            else
            {
                tablename = STableNameDictionary.getdTableName.Where(x => x.Key == tableNameSqlite).FirstOrDefault().Value;
            }
            ConnectionStringName = new SqliteConnection(@"DataSource=" + pathDbFile + tablename).ConnectionString;
        }
    }
}
