using DataAccessLibrary_netCore.ConString;
using DataAccessLibrary_netCore.DataAccess.Command;
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

       

        public ICreateAccessWithQuery CreateConnectForQuery_MSsql(IConfiguration config, string constringTypes)
        {
            constring = new ConnectStringAccess(config, constringTypes);
            return new CreateAccessWithQuery(constring);
        }
        public ICreateAccessWithQuery CreateConnectForQuery_SQLite(string tableNameSqlite)
        {
            constring = new ConnectStringAccess(tableNameSqlite);
            return new CreateAccessWithQuery(constring);
        }

        public ICreateAccessWithCommand CreateConnectForCommand_MSsql(IConfiguration config, string constringTypes)
        {
            constring = new ConnectStringAccess(config, constringTypes);
            return new CreateAccessWithCommand(constring);
        }
        public ICreateAccessWithCommand CreateConnectForCommand_SQLite(string tableNameSqlite)
        {
            constring = new ConnectStringAccess(tableNameSqlite);
            return new CreateAccessWithCommand(constring);
        }
    }
}
