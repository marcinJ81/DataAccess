using DataAccessLibrary_netCore.ConString;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestNunit
{
    class Test_CoonectionString
    {
        private IConnectStringAccess connectStringAccess;
        private string pathDbFile;
        [SetUp]
        public void Setup()
        {
            pathDbFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        [Test]
        public void ShouldGenerateConnectionStringToSQLiteTable_paramteterTableName_Client()
        {
            string tableName = "Client";
            connectStringAccess = new ConnectStringAccess(tableName);
            string conString = connectStringAccess.GetConString; 
            string targetConString = @"DataSource=" + pathDbFile + @"\client.db";
             
            Assert.AreEqual(conString, targetConString);
        }
        [Test]
        public void ShouldtGenerateDefaultConnectionStringToSQLiteTable_parameterTableName_default()
        {
            string tableName = "default";
            connectStringAccess = new ConnectStringAccess(tableName);
            string conString = connectStringAccess.GetConString;
            string targetConString = @"DataSource=" + pathDbFile + @"\client.db";

            Assert.AreEqual(conString, targetConString);
        }
        [Test]
        public void ShouldGenerateConStringForAllTableInDictionary_parameter_DictionarySTableNameDictionary()
        {
            foreach (var i in STableNameDictionary.getdTableName)
            {
                connectStringAccess = new ConnectStringAccess(i.Key);
                string conString = connectStringAccess.GetConString;
                string targetConString = @"DataSource=" + pathDbFile + i.Value;
                Assert.AreEqual(targetConString, conString);
            }
        }
    }
}
