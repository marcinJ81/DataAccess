using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit.Test_Model
{
   public class Test_MVCEmployeeModel
    {


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ShouldGetAnyRecordFromEmployeeTable()
        {
            // This workaround is necessary on Xamarin,
            // which doesn't support async unit test methods.
            Task.Run(async () =>
            {
                // Actual test code here.
            }).GetAwaiter().GetResult();

        }
    }
}
