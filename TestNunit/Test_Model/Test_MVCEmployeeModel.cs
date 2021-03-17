using Dapper;
using DataAccessLibrary_netCore.DataAccess.Command;
using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
using DataAccessLibrary_netCore.DataFromDB.T_Model;
using DataAccessLibrary_netCore.Dependency;
using DataAccessLibrary_netCore.Model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNunit.Test_DependencyContainer;

namespace TestNunit.Test_Model
{
   public class Test_MVCEmployeeModel
    {

        private IConfiguration configuration;
        private ICreateAccessWithQuery accessQuery;
        private ICreateQueryFromDB<ModelEmployee> getDataFromDB;
        private ICommandExecuteNonQuey execNonQuery;
        private ICreateAccessWithCommand command;
        private ICreatorOfDBConnection connectDB;

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
            connectDB = SDependencyContainer.getCreatorOfDBConnection;
            // query
            accessQuery = connectDB.CreateConnectForQuery_MSsql(configuration, "Production");
            getDataFromDB = new DataFromTable_With_Sync_and_Async<ModelEmployee>(accessQuery);
            //command
            command = connectDB.CreateConnectForCommand_MSsql(configuration, "Production");
            execNonQuery = new CommandExecuteNonQuey<ModelEmployee>(command);


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
        [Test]
        public void ShouldInsertOneRow_async()
        {
            int idE = 104;
            DynamicParameters dynamicParameters0 = new DynamicParameters();
            dynamicParameters0.Add("@paramId", idE, DbType.Int32);
            dynamicParameters0.Add("@paramName", "insert", DbType.AnsiStringFixedLength);
            TableScripts tableScripts = new TableScripts() 
            {
                ScriptName = "insert",
                NameTable = "employee",
                Script = "insert into employee ([employee_id],[employee_name]) values (@paramId,@paramName)",
                paramters = dynamicParameters0
            };
            SQuerySelected.GenerateScripts(tableScripts.ScriptName, tableScripts.NameTable, tableScripts.Script, tableScripts.paramters);

            Task.Run(async () =>
            {
                await execNonQuery.ASync_ExecuteNonQuey(tableScripts, dbType.mssql);
                // Actual test code here.
            }).GetAwaiter().GetResult();

            var resultQuery = SQuerySelected.GetScritps;
            var query = resultQuery.Where(x => x.ScriptName == "GetAllEmployees").First();
            var result = getDataFromDB.Sync_GetDataFromTable_Return_T(query, dbType.mssql);
            int id = result.OrderByDescending(x => x.employee_id).FirstOrDefault().employee_id;
            Assert.AreEqual(idE, id);
        }
    }
}
