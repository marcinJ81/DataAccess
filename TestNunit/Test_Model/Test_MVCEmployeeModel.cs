using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
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
        private IQueryEmployee queryEmployee;
        
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
        }

        [Test]
        public void ShouldGetAnyRecordFromEmployeeTable()
        {
           
            queryEmployee = new QueryEmployee(accessQuery);
            Task.Run(async () =>
            {

                var result = await queryEmployee.GetEmployees_async(dbType.mssql);
                // Actual test code here.
                Assert.IsTrue(result.Any());
            }).GetAwaiter().GetResult();

            //List<ModelEmployee> result =  queryEmployee.GetEmployees_sync(dbType.mssql);
            //Assert.IsTrue(result.Any());

        }
    }
}
