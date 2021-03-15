using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.Employee
{
    public interface IQueryEmployee_withParam
    {
        List<ModelEmployee> GetEmployees_sync_param_TableScripts(TableScripts tableScript,dbType db_type);
        Task<List<ModelEmployee>> GetEmployees_async_param_TableScripts(TableScripts tableScript,dbType db_type);
    }
}