using DataAccessLibrary_netCore.DataAccess.Query;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary_netCore.Dependency
{
    public interface ICreatorOfDBConnection
    {
        ISQLDataAccessQuery CreateObject_MSsql(IConfiguration config, string constringTypes);
        ISQLDataAccessQuery CreateObject_SQLite(string tableNameSqlite);
    }
}