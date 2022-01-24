using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppoinmentManagment.Extensions
{
    public static class UserDetailsHttpContextExtension
    {
        public static (int, string) GetUserInfo(this HttpContext httpContext) //tuple can pass multiple value
        {
            try
            {
                return (Convert.ToInt32(httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value), httpContext.User.FindFirst("Name").Value);
            }
            catch (NullReferenceException)
            {
                return (-1, null);
            }
        }

    }
}
