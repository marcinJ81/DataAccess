using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.Employee
{
    public interface IQueryEmployee_withParam
    {
        Task<List<ModelEmployee>> GetEmployeeWithParameters(dbType db_type);
    }
}