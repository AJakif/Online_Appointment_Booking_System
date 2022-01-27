using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Extensions;
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
    [Authorize(Roles = "Doctor")]
    
    public class DoctorController : ControllerBase
    {
        private readonly IAppointmentRepository _appointment;

        public DoctorController( IAppointmentRepository appointment)
        {
            _appointment = appointment;
        }

        #region API
        [HttpGet]
        [Route("api/doctor/getApprovedAppointmnets")]
        public IActionResult Appointments()
        {
            string DrId = HttpContext.GetDrId();
            ListAppoinmentBO labo = new ListAppoinmentBO()
            {
                AppointmentList = _appointment.GetApprovedPaidAppointmentDoctorId(DrId)
            };
            return Ok(labo);
        }

        [HttpPost]
        [Route("api/doctor/givePrescription")]
        public IActionResult Prescription([FromBody] PrescriptionBO labo)
        {
            string prescription = labo.Prescription;
            string appointmentId = labo.AppointmentId;
            string desis = labo.Diesis;
            (_, string name) = HttpContext.GetUserInfo();
            int result = _appointment.Prescribe(appointmentId, prescription, desis, name);
            if (result > 0)
            {
                return Ok(new { message = "Prescribed"});
            }
            else
            {
                return BadRequest(new { message = "Error while prescription, please try again" });
            }
        }

        [HttpGet]
        [Route("api/doctor/appointment/visit/{id}")]
        public IActionResult Visit(string id)
        {
            try
            {
                (_, string name) = HttpContext.GetUserInfo();
                int result = _appointment.VisitAppointment(id, name);
                if (result > 0)
                {
                    return Ok(new { success = true, message = "Visit successful" });
                }
                else
                {
                    return Ok(new { success = false, message = "Error ." });
                }
            }
            catch (NullReferenceException)
            {
                return Ok(new { success = false, message = "Error , please try again!" });
            }
        }

        [HttpGet]
        [Route("api/doctor/appointment/patient/{id}")]
        public IActionResult Patient(string id)
        {
            AppoinmentBO abo = _appointment.GetAppoinmentById(id);

            return Ok( new { data = abo } );
        }
        #endregion
    }
}
