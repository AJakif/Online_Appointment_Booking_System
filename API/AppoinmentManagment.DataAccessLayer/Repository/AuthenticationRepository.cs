using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthenticationRepository> _logger;
        private readonly IUserRepository _user;

        public AuthenticationRepository(IConfiguration config, ILogger<AuthenticationRepository> logger, IUserRepository user)
        {
            _config = config;
            _logger = logger;
            _user = user;
        }

        public int Register(UserModel um)
        {
            string Query = "Insert into [User] ([TypeId] ,[Name] ,[Address] ,[Gender] ,[DOB] ,[Phone] ,[Email]"+
                ",[Password],[Created_at],[Created_by])"+
                $"values (2,'{um.Name}','{um.Address}','{um.Gender}','{um.DOB}','{um.Phone}','{um.Email}','{um.Password}',GETDATE(),'{um.Name}')";
            _logger.LogInformation("Entered in DMLTransaction..");
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Inserted");
                connection.Close();
                return Result;
            }
            catch (Exception e)
            {
                _logger.LogWarning($"'{e}' Exception..");
                connection.Close();
                return -1;
            }
        }

        public bool UserAlreadyExists(UserModel um)
        {
            string query = $"Select * from [User] where Name='{um.Name}'" + $"OR Email = '{um.Email}'";
            _logger.LogInformation("Entered in UserAlreadyExists..");
            bool flag = false;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dr = command.ExecuteReader();
                try
                {
                    if (dr.HasRows)
                    {
                        flag = true;
                        _logger.LogInformation("User Already Exist..");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogWarning($"'{e}' Exception");
                }

                connection.Close();

            }
            return flag;
        }

        public UserBO LoginByEmail(LoginBO lbo)
        {
            string query = $"select * from [User] where Email='{lbo.Email}' and Password='{lbo.Password}'";
            _logger.LogInformation("Login query innitialized and GetUserByEmail class called in common helper class");

            _logger.LogInformation("Entered in GetUserByEmail..");
            UserBO user = new UserBO();

            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    try
                    {
                        while (dataReader.Read()) //make it single user
                        {
                            user.OId = Convert.ToInt32(dataReader["OId"]);
                            user.Type= (_user.GetUserType(Convert.ToInt32(dataReader["TypeId"]))).ToString();
                            user.Name = dataReader["Name"].ToString();
                            user.Address = dataReader["Address"].ToString();
                            user.Gender = dataReader["Gender"].ToString();
                            user.Phone = dataReader["Phone"].ToString();
                            user.DOB = dataReader["DOB"].ToString();
                            user.Email = dataReader["Email"].ToString();
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return user;
        }
    }
}
