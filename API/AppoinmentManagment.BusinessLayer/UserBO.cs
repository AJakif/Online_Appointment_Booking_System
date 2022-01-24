using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class UserBO
    {
        public int OId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<UserBO> UserList { get; set; }
    }
}
