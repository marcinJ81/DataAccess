using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLibrary_netCore.DataAccess.Query
{
    public static class SQuerySelected
    {
        private static List<TableScripts> tableScripts1;
        public static List<TableScripts> GetScritps => tableScripts1;
        static SQuerySelected()
        {
             tableScripts1 = new List<TableScripts>();
            tableScripts1 = GetSavedScrtipts();
        }
        public  static List<TableScripts> GenerateScripts(string sciptName,string nameTable,string script, DynamicParameters paramters)
        {
          
            tableScripts1.Add
                (
                    new TableScripts 
                    { 
                        ScriptName = sciptName,
                        NameTable = nameTable,
                        Script = script,
                        paramters = paramters
                    }
                );
            return tableScripts1;
        }
       
        private static List<TableScripts> GetSavedScrtipts()
        {
          

            DynamicParameters dynamicParameters0 = new DynamicParameters();
            dynamicParameters0.Add("@param_id", 50, DbType.Int32);
            tableScripts1.Add(new TableScripts
            {
                ScriptName = "GetEmloyeeWhenIdBiggerThen",
                NameTable = "Employee",
                Script = "select * from dbo.employee where employee_id > @param_id",
                paramters = dynamicParameters0
            }); ;
            return tableScripts1;
        }
    }
    public class TableScripts
    {
        public string ScriptName { get; set; }
        public string NameTable { get; set; }
        public string Script { get; set; }
        public DynamicParameters paramters { get; set; }
    }
}
