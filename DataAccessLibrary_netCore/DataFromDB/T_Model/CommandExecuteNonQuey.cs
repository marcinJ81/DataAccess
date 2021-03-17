using DataAccessLibrary_netCore.DataAccess.Command;
using DataAccessLibrary_netCore.DataAccess.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary_netCore.DataFromDB.T_Model
{
    public class CommandExecuteNonQuey<T> : ICommandExecuteNonQuey
    {
        private ICreateAccessWithCommand createCommnad;

        public CommandExecuteNonQuey(ICreateAccessWithCommand createCommnad)
        {
            this.createCommnad = createCommnad;
        }

        public async Task ASync_ExecuteNonQuey(TableScripts tableScript, dbType db_type)
        {
            await createCommnad.Async_SaveData<T, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }

        public void Sync_ExecuteNonQuery(TableScripts tableScript, dbType db_type)
        {
            createCommnad.Sync_SaveData<T, dynamic>(tableScript.Script, tableScript.paramters, db_type);
        }
    }
}
