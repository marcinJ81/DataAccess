using DataAccessLibrary2.ConString;
using DataAccessLibrary2.DataAccess.Query;
using DataAccessLibrary2.DataFromDB.Employee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Dependency
{
    public class DependencyInversion : IDependencyInversion
    {
        private IConnectStringAccess constring;
        private ISQLDataAccessQuery query;
        public ISQLDataAccessQuery GetISqlDataAccess => query;

        public DependencyInversion(){}
        private DependencyInversion(IConfiguration config, string constringTypes)
        {
            constring = new ConnectStringAccess(config, constringTypes);
            query = new SQLDataAccessQuery(constring);
        }
        private DependencyInversion(string tableNameSqlite)
        {
            constring = new ConnectStringAccess(tableNameSqlite);
            query = new SQLDataAccessQuery(constring);
        }

        public DependencyInversion CreateObject_MSsql(IConfiguration config, string constringTypes)
        {
            return new DependencyInversion(config, constringTypes);
        }
        public DependencyInversion CreateObject_SQLite(string tableNameSqlite)
        {
            return new DependencyInversion(tableNameSqlite);
        }
    }
}
