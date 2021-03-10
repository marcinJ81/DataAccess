using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary2.ConString
{
    public static class SConnectionStringTypes
    {
        private static Dictionary<string, string> dictionaryTypes { get; set; }
        public static Dictionary<string, string> getdictionaryTypes => (Dictionary<string, string>)dictionaryTypes;
        static SConnectionStringTypes()
        {
            dictionaryTypes = new Dictionary<string, string>();
            dictionaryTypes.Add("Production", "Production");
            dictionaryTypes.Add("Dev", "Dev");
        }

    }
}
