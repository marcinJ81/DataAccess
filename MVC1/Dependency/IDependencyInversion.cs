using DataAccessLibrary2.DataAccess.Query;
using Microsoft.Extensions.Configuration;

namespace MVC1.Dependency
{
    public interface IDependencyInversion
    {
        ISQLDataAccessQuery GetISqlDataAccess { get; }
        DependencyInversion CreateObject_MSsql(IConfiguration config, string constringTypes);
        DependencyInversion CreateObject_SQLite(string tableNameSqlite);
    }
}