using Dapper;
using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.Employee
{
    public class QueryEmployee_withParam : IQueryEmployee_withParam
    {
        private readonly ICreateAccessWithQuery sQLDataAccessQuery;

        public QueryEmployee_withParam(ICreateAccessWithQuery sQLDataAccessQuery)
        {
            this.sQLDataAccessQuery = sQLDataAccessQuery;
        }
        public Task<List<ModelEmployee>> GetEmployees_async_param_TableScripts(TableScripts tableScript, dbType db_type)
        {
            return sQLDataAccessQuery.loadData_async<ModelEmployee, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }

        public List<ModelEmployee> GetEmployees_sync_param_TableScripts(TableScripts tableScript, dbType db_type)
        {
            return sQLDataAccessQuery.loadData_sync<ModelEmployee, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }
    }
}
