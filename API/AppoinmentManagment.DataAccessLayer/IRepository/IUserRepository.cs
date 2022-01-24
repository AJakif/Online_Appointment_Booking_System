using AppoinmentManagment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IUserRepository
    {
        string GetUserType(int type);

        string GetUserName(int id);
    }
}
