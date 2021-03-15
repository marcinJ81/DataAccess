using DataAccessLibrary_netCore.ConString;
using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary_netCore.Model;

namespace TestNunit.Test_Model
{
   public class Test_GetEmployees
    {
        private IConnectStringAccess constring;
        private ISQLDataAccessQuery query;
        [SetUp]
        public void Setup()
        {
            constring = new ConnectStringAccess("Employee");
            query = new SQLDataAccessQuery(constring);
        }

        [Test]
        
        public void ShouldGEtAnyRecordFromDB_paramTabelEmployee()
        {
            Assert.Ignore("Trzeba wywolac asynchroniczne metody na razie nie mwiem jak");
        }

        [Test]
        public void ShouldGEtAnyRecordFromDB_SyncQuery_paramTabelEmployee()
        {
            Assert.Ignore(" You need to call SQLitePCL.raw.SetProvider().  If you are using a bundle package, this is done by calling SQLitePCL.Batteries.Init().");
        }
    }
}
