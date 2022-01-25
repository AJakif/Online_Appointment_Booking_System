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
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    
    public class AdminController : ControllerBase
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
        public IActionResult AddPatient([FromBody] UserModel um)
        {
            _logger.LogInformation("The Register Post method has been called");
            try
            {
                //Query for user existence
                bool userExists = _auth.UserAlreadyExists(um);

                if (userExists == true)
                {
                    return BadRequest(new{ message = "Patient's Name and Email Already Exists" });
                }
                //If user doesn't exists it inserts data into database
                int result = _auth.Register(um);
                if (result > 0)
                {
                    _logger.LogInformation("patient's data Inserted");
                    return Ok(); 
                }
                else
                {
                    return BadRequest(new { message = "Error occured Please contact to It person" });
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Exception - '{e}'");
            }
            return BadRequest(new { message = "Registration Failed, Please Try again!" });
        }


        [HttpPost]
        [Route("api/admin/addspecialization")]
        public IActionResult AddSpecialization([FromBody] SpecializationModel sm)
        {
            _logger.LogInformation("The Specialization Post method has been called");
            try
            {
                //Query for user existence
                bool specializationExists = _special.specAlreadyExists(sm);

                if (specializationExists == true)
                {
                    return BadRequest(new { message = "Specialization Already Exists" });
                }
                
                int result = _special.Add(sm);
                if (result > 0)
                {
                    _logger.LogInformation("specialization data Inserted");
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Error occured Please contact to It person" });
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Exception - '{e}'");
                return BadRequest(new { message = "Specialization Adding Failed, Please Try again!" });
            }
            
        }


        [Route("api/admin/CountPatient")]
        [HttpGet]
        public IActionResult CountPatient()
        {
            int patient = _admin.CountPatient();
            return Ok(new { Patient = patient });
        }

        [HttpGet]
        [Route("api/admin/CountDoctor")]
        public IActionResult CountDoctor()
        {
            int doctor = _admin.CountDoctor();
            return Ok(new { Doctor = doctor });
        }

        [HttpGet]
        [Route("api/admin/CountSpecialization")]
        public IActionResult CountSpecialization()
        {
            int special = _admin.CountSpecialization();
            return Ok(new { Special = special });
        }

        [HttpGet]
        [Route("api/admin/Balance")]
        public IActionResult Balance()
        {
            int balance = _admin.TotalBalance();
            return Ok(new { Balance = balance });
        }

        [HttpGet]
        [Route("api/admin/GetAllPatient")]
        public IActionResult GetAllPatientList()
        {
            List<UserBO> user = _admin.GetAllPatientList();
            return Ok(new { data = user});
        }

        [HttpGet]
        [Route("api/admin/Report/monthlyDeposit/")]
        public IActionResult GetMonthlyDeposit()
        {
            List<MonthlyDepositBO> mdbol = _admin.GetMonthlyDeposit();
            return Ok(mdbol);
        }

        [HttpGet]
        [Route("api/admin/Report/yearlyDeposit")]
        public IActionResult GetYearlyDeposit()
        {
            return Ok(_admin.GetYearlyDeposit());
        }
        #endregion
    }
}
