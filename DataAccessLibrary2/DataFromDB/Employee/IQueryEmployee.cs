using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.Employee
{
    public interface IQueryEmployee
    {
        Task<List<ModelEmployee>> GetEmployees_async(dbType db_type);
        List<ModelEmployee> GetEmployees_sync(dbType db_type);
    }
}