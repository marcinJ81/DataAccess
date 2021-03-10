using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataAccess.Query
{
    public interface ISQLDataAccessQuery
    {
        Task<List<T>> loadData_async<T, U>(string sql, U parameters, dbType db_Type);
        List<T> loadData_sync<T, U>(string sql, U parameters, dbType db_Type);
    }
}