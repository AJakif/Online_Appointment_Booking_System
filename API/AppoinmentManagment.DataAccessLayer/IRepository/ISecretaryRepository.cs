using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface ISecretaryRepository
    {
        string GetDrId(int id);
    }
}
