using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoinmentManagment.Models
{
    public class TransactionModel
    {
        public string TransId { get; set; }
        public int PatientId { get; set; }
        public string DoctorId { get; set; }
        [Required]
        public string AppointmentId { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
