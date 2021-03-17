using DataAccessLibrary_netCore.DataAccess.Query;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataAccess.Command
{
    public interface ICreateAccessWithCommand
    {
        Task Async_SaveData<T, U>(string sql, U parameters, dbType db_Type);
        void Sync_SaveData<T, U>(string sql, U parameters, dbType db_Type);
    }
}