using AppoinmentManagment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IAdminApiRepository
    {
        int CountPatient();
        int CountDoctor();
        int CountSpecialization();
        int TotalBalance();

        List<MonthlyDepositBO> GetMonthlyDeposit();
        List<Monthly> GetYearlyDeposit();
        List<UserBO> GetAllPatientList();
    }
}
