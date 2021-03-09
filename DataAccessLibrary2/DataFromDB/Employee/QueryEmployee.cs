using DataAccessLibrary2.DataAccess.Query;
using DataAccessLibrary2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccessLibrary2.DataFromDB.Employee
{
    public class QueryEmployee : IQueryEmployee
    {
        private readonly ISQLDataAccessQuery sQLDataAccessQuery;
        public QueryEmployee(ISQLDataAccessQuery sQLDataAccessQuery)
        {
            this.sQLDataAccessQuery = sQLDataAccessQuery;
        }
        public Task<List<ModelEmployee>> GetEmployees_async(dbType db_type)
        {
            string sql = "select employee_id,employee_name from dbo.employee";
            return sQLDataAccessQuery.loadData_async<ModelEmployee, dynamic>(sql, new { },db_type);
        }

        public List<ModelEmployee> GetEmployees_sync(dbType db_type)
        {
            string sql = "select employee_id,employee_name from dbo.employee";
            return sQLDataAccessQuery.loadData_sync<ModelEmployee, dynamic>(sql, new { }, db_type);
        }
    }
}
