using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLibrary_netCore.DataAccess.Query
{
    public static class SQuerySelected
    {
        public  static List<TableScripts> GenerateScripts(string sciptName,string nameTable,string script, DynamicParameters paramters)
        {
            List<TableScripts> tableScripts = new List<TableScripts>();
            tableScripts.Add
                (
                    new TableScripts 
                    { 
                        ScriptName = sciptName,
                        NameTable = nameTable,
                        Script = script,
                        paramters = paramters
                    }
                );
            return tableScripts;
        }
       
        public static List<TableScripts> GetSavedScrtipts()
        {
            List<TableScripts> tableScripts = new List<TableScripts>();

            DynamicParameters dynamicParameters0 = new DynamicParameters();
            dynamicParameters0.Add("@param_id", 50, DbType.Int32);
            tableScripts.Add(new TableScripts
            {
                ScriptName = "GetEmloyeeWhenIdBiggerThen",
                NameTable = "Employee",
                Script = "select * from dbo.employee where employee_id > @param_id",
                paramters = dynamicParameters0
            }); ;
            return tableScripts;
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
