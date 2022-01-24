using AppoinmentManagment.DataAccessLayer.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.Repository
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SecretaryRepository> _logger;

        public SecretaryRepository(IConfiguration config, ILogger<SecretaryRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string GetDrId(int id)
        {
            try {
                string query = $"SELECT [DrId] FROM[Hospital].[dbo].[Secretary] Where UserId = '{id}'";
                _logger.LogInformation("Login query innitialized and GetUserByEmail class called in common helper class");
                string drId = "";
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
                                drId = dataReader["DrId"].ToString();
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            _logger.LogWarning($"'{e}' Exception");
                        }
                    }
                    connection.Close();
                }
                return drId;
            }
            catch(Exception e) {
                _logger.LogWarning("Error = " + e);
                return null;
            }
            
        }
    }
}
