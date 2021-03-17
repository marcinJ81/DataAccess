using DataAccessLibrary_netCore.DataAccess.Command;
using DataAccessLibrary_netCore.DataAccess.Query;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary_netCore.Dependency
{
    public interface ICreatorOfDBConnection
    {
        ICreateAccessWithQuery CreateConnectForQuery_MSsql(IConfiguration config, string constringTypes);
        ICreateAccessWithQuery CreateConnectForQuery_SQLite(string tableNameSqlite);
        ICreateAccessWithCommand CreateConnectForCommand_MSsql(IConfiguration config, string constringTypes);
        ICreateAccessWithCommand CreateConnectForCommand_SQLite(string tableNameSqlite);
    }
}