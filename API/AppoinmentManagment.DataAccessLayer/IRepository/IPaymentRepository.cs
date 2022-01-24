using AppoinmentManagment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IPaymentRepository
    {
        decimal GetDoctorFeesById(string id);
        int AddTransaction(ListAppoinmentBO listabo,string trasid, int userid, string drid,string name);
    }
}
