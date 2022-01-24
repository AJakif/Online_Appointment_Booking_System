using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.BusinessLayer
{
    public class YearlyDepositBO
    {
        public decimal Total { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
    }
    public class Monthly
    {
        public string Month { get; set; }
        public List<YearlyDepositBO> List { get; set; }

    }
}
