using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary_netCore.ConString
{
    public static class STableNameDictionary
    {
        private static Dictionary<string, string> TableName { get; set; }
        public static Dictionary<string, string> getdTableName => (Dictionary<string, string>)TableName;
        static STableNameDictionary()
        {
            TableName = new Dictionary<string, string>
            {
                { "Client", @"\client.db" },
                { "Employee", @"\employee.db" },
                { "Reservation", @"\reservation.db" },
                { "Services", @"\services.db" }
            };
        }
    }
}
