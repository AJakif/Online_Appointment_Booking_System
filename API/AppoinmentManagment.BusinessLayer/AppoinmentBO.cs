using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class AppoinmentBO
    {
        
        public string AppointmentId { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        
        [Required]
        public string DoctorId { get; set; }

        [Required]
        public string AppointmentDate { get; set; }

        [Required]
        public string AppointmentTime { get; set; }

        [Required]
        public string AppointmentStatus { get; set; }

        [Required]
        public string Symptom { get; set; }

        [Required]
        public string Medication { get; set; }

        public string Diesis { get; set; }

        public string Prescription { get; set; }

        public int IsVisited { get; set; }
        public int IsPaid { get; set; }

        public int IsPrescribed { get; set; }

        public List<AppoinmentBO> AppoinmentList { get; set; }
    }
}
