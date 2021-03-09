using DataAccessLibrary2.DataAccess.Query;
using DataAccessLibrary2.Model;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLibrary2.DataFromDB.Employee
{
    public interface IQueryEmployee
    {
        Task<List<ModelEmployee>> GetEmployees_async(dbType db_type);
        List<ModelEmployee> GetEmployees_sync(dbType db_type);
    }
}