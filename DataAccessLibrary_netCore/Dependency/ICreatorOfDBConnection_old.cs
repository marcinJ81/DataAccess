using DataAccessLibrary_netCore.DataAccess.Query;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary_netCore.Dependency
{
    public interface ICreatorOfDBConnectionold
    {
        ICreateAccessWithQuery GetISqlDataAccess { get; }
        CreatorOfDBConnection CreateObject_MSsql(IConfiguration config, string constringTypes);
        CreatorOfDBConnection CreateObject_SQLite(string tableNameSqlite);
    }
}