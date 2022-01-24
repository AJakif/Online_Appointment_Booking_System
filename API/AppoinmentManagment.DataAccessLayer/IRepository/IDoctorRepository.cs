using AppoinmentManagment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IDoctorRepository
    {
        List<DoctorBO> GetDoctorBySpecialization(int id);
        string GetDoctorName(string id);

        string GetDrId(int id);

    }
}
