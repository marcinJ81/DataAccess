using DataAccessLibrary_netCore.DataAccess.Query;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.T_Model
{
    public interface ICommandExecuteNonQuey
    {
        Task ASync_ExecuteNonQuey(TableScripts tableScript, dbType db_type);
        void Sync_ExecuteNonQuery(TableScripts tableScript, dbType db_type);
    }
}