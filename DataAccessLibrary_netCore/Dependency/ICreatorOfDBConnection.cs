using DataAccessLibrary_netCore.DataAccess.Query;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary_netCore.Dependency
{
    public interface ICreatorOfDBConnection
    {
        ISQLDataAccessQuery GetISqlDataAccess { get; }
        CreatorOfDBConnection CreateObject_MSsql(IConfiguration config, string constringTypes);
        CreatorOfDBConnection CreateObject_SQLite(string tableNameSqlite);
    }
}