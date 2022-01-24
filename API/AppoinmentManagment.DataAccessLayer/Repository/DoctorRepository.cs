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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DoctorRepository> _logger;
        private readonly IUserRepository _user;

        public DoctorRepository(IConfiguration config, ILogger<DoctorRepository> logger, IUserRepository user)
        {
            _config = config;
            _logger = logger;
            _user = user;
        }

        public List<DoctorBO> GetDoctorBySpecialization(int id)
        {
            string query = $"SELECT * FROM[Hospital].[dbo].[Doctor] WHERE SpecializationId = '{id}'";

            _logger.LogInformation("Entered in Get doctor..");
            List<DoctorBO> dbol = new List<DoctorBO>();

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
                        while (dataReader.Read()) 
                        {
                            DoctorBO dbo = new DoctorBO()
                            {
                                DrId = dataReader["DrId"].ToString(),
                                UserId = Convert.ToInt32(dataReader["UserId"]),
                                Name = _user.GetUserName(Convert.ToInt32(dataReader["UserId"])).ToString(),
                                SpecializationId = Convert.ToInt32(dataReader["SpecializationId"])
                            };
                            dbol.Add(dbo);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return dbol;
        }

        
        public string GetDoctorName(string id)
        {
            var name = "";
            string Query = $"SELECT [UserId] FROM[Hospital].[dbo].[Doctor]  where [DrId] = '{id}'";
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read()) //make it single user
                        {
                            name = _user.GetUserName(Convert.ToInt32(dataReader["UserId"])).ToString();
                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }
                    return name;
                }
                catch (Exception e)
                {
                    _logger.LogWarning($"'{e}' Exception");
                    connection.Close();
                    return null;
                }

            }
            catch (Exception e)
            {
                _logger.LogWarning($"'{e}' Exception");
                connection.Close();
                return null;
            }
        }

        public string GetDrId(int id)
        {
            try
            {
                string query = $"SELECT [DrId] FROM[Hospital].[dbo].[Doctor] Where [UserId] = '{id}'";
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
            catch (Exception e)
            {
                _logger.LogWarning("Error = " + e);
                return null;
            }
        }
    }
}
