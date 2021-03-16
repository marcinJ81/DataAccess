using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.T_Model
{
    public class DataFromTable_With_Sync_and_Async<T> : ICreateQueryFromDB<T>
    {
        private readonly ISQLDataAccessQuery getDataFromDB;
        public DataFromTable_With_Sync_and_Async(ISQLDataAccessQuery sQLDataAccessQuery )
        {
            getDataFromDB = sQLDataAccessQuery;
        }
        public Task<List<T>> ASync_GetDataFromTable_Return_T(TableScripts tableScript, dbType db_type)
        {
            return getDataFromDB.loadData_async<T, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }

        public List<T> Sync_GetDataFromTable_Return_T(TableScripts tableScript, dbType db_type)
        {
            return getDataFromDB.loadData_sync<T, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }
    }
}
