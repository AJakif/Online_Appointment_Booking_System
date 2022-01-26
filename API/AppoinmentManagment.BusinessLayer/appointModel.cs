using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class AppointModel
    {
        public string Specialization { get; set; }

        [Required]
        public string DoctorId { get; set; }

        [Required]
        public string AppointmentDate { get; set; }

        [Required]
        public string AppointmentTime { get; set; }

        
        public string AppointmentStatus { get; set; }

        [Required]
        public string Symptom { get; set; }

        [Required]
        public string Medication { get; set; }

       
    }
}
