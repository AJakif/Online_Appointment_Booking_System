using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppoinmentManagment.Extensions
{
    public static class DoctorIdHttpContextExtension
    {
        public static string GetDrId(this HttpContext httpContext) 
        {
            try
            {
                return httpContext.User.FindFirst("DoctorId").Value;
            }
            catch (NullReferenceException)
            {
                return ( null);
            }
        }
    }
}
