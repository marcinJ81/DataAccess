﻿using DataAccessLibrary2.ConString;
using DataAccessLibrary2.DataAccess.Query;
using DataAccessLibrary2.DataFromDB.Employee;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Dependency
{
    /// <summary>
    /// name of class is not good
    /// </summary>
    /// CreatorOfDBConnection
    public class CreatorOfDBConnection : ICreatorOfDBConnection
    {
        private IConnectStringAccess constring;
        private ISQLDataAccessQuery query;
        /// <summary>
        /// this is not gut solution, pattern?
        /// </summary>
        public ISQLDataAccessQuery GetISqlDataAccess => query;

        public CreatorOfDBConnection(){}
        private CreatorOfDBConnection(IConfiguration config, string constringTypes)
        {
            constring = new ConnectStringAccess(config, constringTypes);
            query = new SQLDataAccessQuery(constring);
        }
        private CreatorOfDBConnection(string tableNameSqlite)
        {
            constring = new ConnectStringAccess(tableNameSqlite);
            query = new SQLDataAccessQuery(constring);
        }

        public CreatorOfDBConnection CreateObject_MSsql(IConfiguration config, string constringTypes)
        {
            return new CreatorOfDBConnection(config, constringTypes);
        }
        public CreatorOfDBConnection CreateObject_SQLite(string tableNameSqlite)
        {
            return new CreatorOfDBConnection(tableNameSqlite);
        }
    }
}