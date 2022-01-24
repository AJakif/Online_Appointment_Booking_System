using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppoinmentManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyRepository _comp;

        public HomeController(ILogger<HomeController> logger, ICompanyRepository comp)
        {
            _logger = logger;
            _comp = comp;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("The main page has been accessed");
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API

        [Route("/company/info")]
        public JsonResult GetCompanyInfo()
        {
            CompanyModel cmp = _comp.GetInfo();
            return Json(new {data = cmp});
        }
        #endregion
    }
}
