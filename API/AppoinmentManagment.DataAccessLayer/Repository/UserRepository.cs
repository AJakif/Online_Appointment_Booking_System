using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IConfiguration config, ILogger<UserRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string GetUserName(int id)
        {
            string query = $"select [Name] from [User] where OId = '{id}'";

            _logger.LogInformation("Getting user type..");
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
                            user.Name = dataReader["Name"].ToString();
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return user.Name;
        }

        public string GetUserType(int type)
        {
            string query = $"select [Type] from [UserType] where OId = '{type}'";

            _logger.LogInformation("Getting user type..");
            string Type = "";

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
                            Type = dataReader["Type"].ToString();
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return Type;
        }
    }
}
