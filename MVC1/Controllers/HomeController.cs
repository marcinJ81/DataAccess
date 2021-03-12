using DataAccessLibrary_netCore.ConString;
using DataAccessLibrary_netCore.DataAccess.Query;
using DataAccessLibrary_netCore.DataFromDB.Employee;
using DataAccessLibrary_netCore.Dependency;
using DataAccessLibrary_netCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICreatorOfDBConnection connectToMSSql;
        private IQueryEmployee queryEmployee;
        private IQueryEmployee_withParam queryEmployee_With;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ICreatorOfDBConnection connectToMSSql)
        {
            _logger = logger;
            queryEmployee = new QueryEmployee(connectToMSSql.CreateObject_MSsql(configuration, "Production"));
            queryEmployee_With = new QueryEmployee_withParam(connectToMSSql.CreateObject_MSsql(configuration, "Production"));
        }

        public async Task<ActionResult> Index()
        {
            // var employee = await queryEmployee.GetEmployees_async(dbType.mssql);
            var employee = await queryEmployee_With.GetEmployeeWithParameters(dbType.mssql);
            return View(employee);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
