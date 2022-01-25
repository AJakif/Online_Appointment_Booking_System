using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppoinmentManagment.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationRepository _auth;
        private readonly IUserRepository _user;
        private readonly ISecretaryRepository _secretary;
        private readonly IDoctorRepository _doctor;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationRepository auth, IUserRepository user, ISecretaryRepository secretary, IDoctorRepository doctor, IConfiguration configuration)
        {
            _logger = logger;
            _auth = auth;
            _user = user;
            _secretary = secretary;
            _doctor = doctor;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] UserModel um)
        {
            _logger.LogInformation("The Register Post methhod has been called");
            try
            {
                //Query for user existence
                bool userExists = _auth.UserAlreadyExists(um);

                if (userExists == true)
                {
                    return BadRequest(new { message = "Name and Email Already Exists" });
                }
                //If user doesn't exists it inserts data into database
                int result = _auth.Register(um);
                if (result > 0)
                {
                    _logger.LogInformation("User data Inserted");
                    return Ok(); //Redirects to Home accounts index view
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Exception - '{e}'");
            }
            return BadRequest(new { message = "Registration Failed, Please Try again!" });
        }


        [Route("api/login")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginBO lbo)
        {
            try
            {
                UserBO userDetails = _auth.LoginByEmail(lbo);
                //int typeId = userDetails.TypeId;
                //UserBO user = _user.GetUserType(typeId);
                _logger.LogInformation($"Userdetails '{userDetails}'");

                if (userDetails != null && userDetails.Email != null) //all data should be null checked
                {
                    if (userDetails.Type == "Secretary")
                    {
                        string id = _secretary.GetDrId(userDetails.OId);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,userDetails.Email),
                            new Claim("Name", userDetails.Name),
                            new Claim(ClaimTypes.NameIdentifier, userDetails.OId.ToString()),
                            new Claim(ClaimTypes.Role,userDetails.Type),
                            new Claim("DoctorId", id)
                        };
                        _logger.LogInformation("secretary Email, Name and Id , doctor id set on claim");
                        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                        var token = new JwtSecurityToken(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddMinutes(30),
                            claims: claims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            userDetails
                        });
                    }
                    else if (userDetails.Type == "Doctor")
                    {
                        string id = _doctor.GetDrId(userDetails.OId);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,userDetails.Email),
                            new Claim("Name", userDetails.Name),
                            new Claim(ClaimTypes.NameIdentifier, userDetails.OId.ToString()),
                            new Claim(ClaimTypes.Role,userDetails.Type),
                            new Claim("DoctorId", id)
                        };
                        _logger.LogInformation("secretary Email, Name and Id , doctor id set on claim");
                        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                        var token = new JwtSecurityToken(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddMinutes(30),
                            claims: claims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            userDetails
                        });
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email,userDetails.Email),
                            new Claim("Name", userDetails.Name),
                            new Claim(ClaimTypes.NameIdentifier, userDetails.OId.ToString()),
                            new Claim(ClaimTypes.Role,userDetails.Type)

                        };
                        _logger.LogInformation("User Email, Name and Id set on claim");
                        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                        var token = new JwtSecurityToken(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddMinutes(10),
                            claims: claims,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            userDetails
                        });
                    }
                }
                else
                {
                    return BadRequest(new { message = "Wrong Email & Password, please try again" });
                }
            }
            catch (NullReferenceException e)
            {
                _logger.LogError("Exception", e);
                return Unauthorized();
            }
        }

    }
}
