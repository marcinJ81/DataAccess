using DataAccessLibrary_netCore.ConString;
using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.Dependency
{

    public class CreatorOfDBConnection : ICreatorOfDBConnection
    {
        private IConnectStringAccess constring;
      
        public CreatorOfDBConnection() { }

        public ISQLDataAccessQuery CreateObject_MSsql(IConfiguration config, string constringTypes)
        {
            constring = new ConnectStringAccess(config, constringTypes);
            return new SQLDataAccessQuery(constring);
        }
        public ISQLDataAccessQuery CreateObject_SQLite(string tableNameSqlite)
        {
            constring = new ConnectStringAccess(tableNameSqlite);
            return new SQLDataAccessQuery(constring);
        }
    }
}
