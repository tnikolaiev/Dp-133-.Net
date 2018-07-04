using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ras.BLL.Implementation;
using Ras.DAL.Implementation;
using Ras.BLL.DTO;

namespace Ras.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // example
            using (var db = new DAL.EF.RasContext("Server=localhost;user id=ras;database = ss_ps_db;Pwd=1111;persistsecurityinfo = True;"))
            {
                //var a = db.Groups.ToList();

            }
            _logger.LogInformation("Index page succesfully loaded!");
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
