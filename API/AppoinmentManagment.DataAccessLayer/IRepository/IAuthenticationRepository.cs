using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IAuthenticationRepository
    {
        bool UserAlreadyExists(UserModel um);

        int Register(UserModel um);

        UserBO LoginByEmail(LoginBO lbo);
    }
}
