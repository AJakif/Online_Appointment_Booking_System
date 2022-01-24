using AppoinmentManagment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface ISpecializationRepository
    {
        bool specAlreadyExists(SpecializationModel sm);
        int Add(SpecializationModel sm);

        List<SpecializationModel> GetAllSpecialization();
    }
}
