﻿using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Extensions;
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
    [Authorize(Roles = "Patient")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IAppointmentRepository _appointment;
        private readonly ISpecializationRepository _special;
        private readonly IDoctorRepository _doctor;
        private readonly IPaymentRepository _payment;

        public PatientController(ILogger<PatientController> logger, IAppointmentRepository appointment, ISpecializationRepository special, IDoctorRepository doctor, IPaymentRepository payment)
        {
            _logger = logger;
            _appointment = appointment;
            _special = special;
            _doctor = doctor;
            _payment = payment;
        }


        #region API

        [HttpGet]
        [Route("api/patient/appointments")]
        public IActionResult Appointments()
        {
            (int id, _) = HttpContext.GetUserInfo();
            ListAppoinmentBO labo = new ListAppoinmentBO()
            {
                AppointmentList = _appointment.GetApprovedAppointmentPatientId(id)
            };
            return View(labo);
        }

        [HttpPost]
        [Route("api/patient/payment")]
        public IActionResult Pay([FromForm] ListAppoinmentBO listabo)
        {
            try
            {
                var date = DateTime.Now;
                string transactionId = "trans" + date.ToString("yyyyMMdd-HHmmssfff");
                (int userId, string name) = HttpContext.GetUserInfo();
                string DrId = _appointment.GetAppointedDoctorId(listabo.Appointment.AppointmentId);
                int result = _payment.AddTransaction(listabo, transactionId, userId,DrId,name);
                if(result>0)
                {
                    string appointId = listabo.Appointment.AppointmentId;
                    int uresult = _appointment.UpdateAppointmentPayment(appointId, name);
                    if(uresult>0)
                    {
                        ListAppoinmentBO labo = new ListAppoinmentBO()
                        {
                            AppointmentList = _appointment.GetApprovedAppointmentPatientId(userId)
                        };
                        return Ok(labo);
                    }
                }
                else
                {
                    return BadRequest(new { message = "error while transaction, please try again!" });
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning($"'{e}' exception..");
                return BadRequest(new { message = "error while transaction, please try again!" });
            }
            return BadRequest(new { message = "error while transaction, please try again!" });
        }

        [HttpPost]
        [Route("api/patient/giveAppoinment")]
        public IActionResult Appointment([FromForm] AppoinmentBO abo)
        {
            (int id, _) = HttpContext.GetUserInfo();
            (_, string name) = HttpContext.GetUserInfo();
            _logger.LogInformation("The Appoinment Post method has been called");
            try
            {
                //Query for user existence
                var date = DateTime.Now;
                string appointId = "app"+date.ToString("yyyyMMdd-HHmmssfff");
                bool applicationExists = _appointment.AppointmentAlreadyExists( abo, id);

                if (applicationExists == true)
                {
                    return BadRequest(new { message = "Appointment for this doctor on the date already exists" });
                }

                int result = _appointment.Add(abo,id,name, appointId);
                if (result > 0)
                {
                    _logger.LogInformation("Appointment data Inserted");
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
                return BadRequest(new { message = "Appointment Adding Failed, Please Try again!" }); ;
            }
        }


        [HttpPost]
        [Route("api/patient/appointment/details/{id}")]
        public JsonResult Patient(string id)
        {
            AppoinmentBO abo = _appointment.GetAppoinmentById(id);

            return Json(new { data = abo });
        }

        [HttpPost]
        [Route("api/patient/doctorFee")]
        public JsonResult Payment(string id)
        {
            decimal fees = _payment.GetDoctorFeesById(id);
            return Json(new { Fee = fees, Appointment = id });

        }

        [Route("api/patient/specialization/all")]
        public JsonResult GetAllSpecialization()
        {
            List<SpecializationModel> sml = _special.GetAllSpecialization();
            return Json(new { data = sml});
        }

        [Route("api/patient/getdoctor/{id}")]
        public JsonResult GetDoctorBySpecialization(int id)
        {
            List<DoctorBO> doc = _doctor.GetDoctorBySpecialization(id);

            return Json(new { data = doc});
        }
        #endregion
    }
}