using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
