using AppoinmentManagment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class ListAppoinmentBO
    {
        public List<AppoinmentBO> AppointmentList { get; set; }
        public AppoinmentBO Appointment { get; set; }
        public TransactionModel Transaction { get; set; }
    }
}
