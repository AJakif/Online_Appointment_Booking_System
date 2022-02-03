using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class DoctorBO
    {
            public string DrId { get; set; }

            public int UserId { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public int SpecializationId { get; set; }

            public string Specialization { get; set; }

            public string Phone { get; set; }

            public string Address { get; set; }

            public string JoinDate { get; set; }

            public decimal Fee { get; set; }

        }
    }