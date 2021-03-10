using DataAccessLibrary2.ConString;
using DataAccessLibrary2.DataAccess.Query;
using DataAccessLibrary2.DataFromDB.Employee;
using DataAccessLibrary2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVC1.Dependency;
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

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ICreatorOfDBConnection connectToMSSql)
        {
            _logger = logger;
            this.connectToMSSql = connectToMSSql.CreateObject_MSsql(configuration, "Production");
            queryEmployee = new QueryEmployee(this.connectToMSSql.GetISqlDataAccess);

        }

        public async Task<ActionResult> Index()
        {
            var employee = await queryEmployee.GetEmployees_async(dbType.mssql);
            return View(employee);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
