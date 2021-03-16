using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
using DataAccessLibrary_netCore.DataFromDB.T_Model;
using DataAccessLibrary_netCore.Dependency;
using DataAccessLibrary_netCore.Model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNunit.Test_DependencyContainer;

namespace TestNunit.Test_Model
{
   public class Test_MVCEmployeeModel
    {

        private IConfiguration configuration;
        private ISQLDataAccessQuery accessQuery;
        private ICreateQueryFromDB<ModelEmployee> getDataFromDB; 

        [SetUp]
        public void Setup()
        {
            //mockhttps://stackoverflow.com/questions/64794219/how-to-mock-iconfiguration-getvalue
            var inMemorySettings = new Dictionary<string, string> {
                {"TopLevelKey", "TopLevelValue"},
                {"ConnectionStrings:Production", "Data Source=ZIT-D0998\\SQL2014; Initial Catalog = salonfr2; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"},
                //...populate as needed for the test
            };

            this.configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            var result = SDependencyContainer.getCreatorOfDBConnection;
            accessQuery = result.CreateObject_MSsql(configuration, "Production");
            getDataFromDB = new DataFromTable_With_Sync_and_Async<ModelEmployee>(accessQuery);
        }

        [Test]
        public void ShouldGetAnyRecordFromEmployeeTable_sync()
        {

           
            var resultQuery = SQuerySelected.GetScritps;
            var query = resultQuery.Where(x => x.ScriptName == "GetAllEmployees").First();
            var result = getDataFromDB.Sync_GetDataFromTable_Return_T(query,dbType.mssql);          
            Assert.IsTrue(result.Any());

        }
       
        [Test]
        public void ShoulGetRows_asyncSQueryDictionary()
        {
           
            var resultQuery = SQuerySelected.GetScritps;
            var query = resultQuery.Where(x => x.ScriptName == "GetEmloyeeWhenIdBiggerThen").First();
            Task.Run(async () =>
            { 
                var result = await getDataFromDB.ASync_GetDataFromTable_Return_T(query,dbType.mssql);
                // Actual test code here.
                Assert.Greater(result.Count, 19);

            }).GetAwaiter().GetResult();
        }

        [Test]
        public void ShouldGetAllRows_asyncSQuery_TableScripts()
        {
            
            var resultQuery = SQuerySelected.GetScritps;

            var query = resultQuery.Where(x => x.ScriptName == "GetAllEmployees").First();
            Task.Run(async () =>
            {
                var result = await getDataFromDB.ASync_GetDataFromTable_Return_T(query, dbType.mssql);
                // Actual test code here.
                Assert.Greater(result.Count, 0);

            }).GetAwaiter().GetResult();

        }
    }
}
