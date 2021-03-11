using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.Employee
{
   public class QueryEmployee_withParam
    {
        private readonly ISQLDataAccessQuery sQLDataAccessQuery;

        public QueryEmployee_withParam(ISQLDataAccessQuery sQLDataAccessQuery)
        {
            this.sQLDataAccessQuery = sQLDataAccessQuery;
        }

        public Task<List<ModelEmployee>> GetEmployeeWithParameters(dbType db_type)
        {
            string sql = "select employee_id,employee_name from dbo.employee";
            return sQLDataAccessQuery.loadData_async<ModelEmployee, dynamic>(sql, new { }, db_type);
        }
    }
}
