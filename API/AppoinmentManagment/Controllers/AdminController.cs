using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppoinmentManagment.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminApiRepository _admin;
        private readonly IAuthenticationRepository _auth;
        private readonly ILogger<AdminController> _logger;
        private readonly ISpecializationRepository _special;

        public AdminController(IAdminApiRepository admin, IAuthenticationRepository auth, ILogger<AdminController> logger, ISpecializationRepository special)
        {
            _admin = admin;
            _auth = auth;
            _logger = logger;
            _special = special;
        }
        #region API
        [HttpPost]
        [Route("api/admin/addpatient")]
        public IActionResult AddPatient([FromForm] UserModel um)
        {
            _logger.LogInformation("The Register Post method has been called");
            try
            {
                //Query for user existence
                bool userExists = _auth.UserAlreadyExists(um);

                if (userExists == true)
                {
                    ViewBag.Error = "Patient's Name and Email Already Exists";
                    return View();
                }
                //If user doesn't exists it inserts data into database
                int result = _auth.Register(um);
                if (result > 0)
                {
                    _logger.LogInformation("patient's data Inserted");
                    return RedirectToRoute("Admindashboard"); 
                }
                else
                {
                    ViewBag.Error = "Error occured Please contact to It person";
                    return View();
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Exception - '{e}'");
                ViewBag.Error = "Registration Failed, Please Try again!";
            }
            return View();
        }


        [HttpPost]
        [Route("api/admin/addspecialization")]
        public IActionResult AddSpecialization([FromForm] SpecializationModel sm)
        {
            _logger.LogInformation("The Specialization Post method has been called");
            try
            {
                //Query for user existence
                bool specializationExists = _special.specAlreadyExists(sm);

                if (specializationExists == true)
                {
                    ViewBag.Error = "Specialization Already Exists";
                    return View();
                }
                
                int result = _special.Add(sm);
                if (result > 0)
                {
                    _logger.LogInformation("specialization data Inserted");
                    return RedirectToRoute("Admindashboard");
                }
                else
                {
                    ViewBag.Error = "Error occured Please contact to It person";
                    return View();
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Exception - '{e}'");
                ViewBag.Error = "Specialization Adding Failed, Please Try again!";
                return View();
            }
            
        }


        [Route("api/admin/CountPatient")]
        public JsonResult CountPatient()
        {
            int patient = _admin.CountPatient();
            return Json(new { Patient = patient });
        }

        
        [Route("api/admin/CountDoctor")]
        public JsonResult CountDoctor()
        {
            int doctor = _admin.CountDoctor();
            return Json(new { Doctor = doctor });
        }

        
        [Route("api/admin/CountSpecialization")]
        public JsonResult CountSpecialization()
        {
            int special = _admin.CountSpecialization();
            return Json(new { Special = special });
        }

        
        [Route("api/admin/Balance")]
        public JsonResult Balance()
        {
            int balance = _admin.TotalBalance();
            return Json(new { Balance = balance });
        }

        
        [Route("api/admin/GetAllPatient")]
        public JsonResult GetAllPatientList()
        {
            List<UserBO> user = _admin.GetAllPatientList();
            return Json(new { data = user});
        }

        [Route("api/admin/Report/monthlyDeposit/")]
        public JsonResult GetMonthlyDeposit()
        {
            List<MonthlyDepositBO> mdbol = _admin.GetMonthlyDeposit();
            return Json(mdbol);
        }

        [Route("api/admin/Report/yearlyDeposit")]
        public JsonResult GetYearlyDeposit()
        {
            return Json(_admin.GetYearlyDeposit());
        }
        #endregion
    }
}
