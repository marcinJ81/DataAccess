using DataAccessLibrary_netCore.DataAccess.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.T_Model
{
    public interface ICreateQueryFromDB<T>
    {
        List<T> Sync_GetDataFromTable_Return_T(TableScripts tableScript, dbType db_type);
        Task<List<T>> ASync_GetDataFromTable_Return_T(TableScripts tableScript, dbType db_type);
    }
}
