using AppoinmentManagment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface ICompanyRepository
    {
        CompanyModel GetInfo();
    }
}
