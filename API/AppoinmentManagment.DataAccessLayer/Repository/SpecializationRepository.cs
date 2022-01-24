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
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SpecializationRepository> _logger;

        public SpecializationRepository(IConfiguration config, ILogger<SpecializationRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public int Add(SpecializationModel sm)
        {
            string Query = $"INSERT INTO [dbo].[Specialization]([Specialization],[Created_at],[Created_by]) VALUES ( '{sm.Specialiaztion}',GETDATE(),'Admin')";
            
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

        public List<SpecializationModel> GetAllSpecialization()
        {
            string query = $"SELECT * FROM[Hospital].[dbo].[Specialization]";

            _logger.LogInformation("Entered in Get Specialization..");
            List<SpecializationModel> sml = new List<SpecializationModel>();

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
                            SpecializationModel sm = new SpecializationModel()
                            {
                                OId = Convert.ToInt32(dataReader["OId"]),
                                Specialiaztion = dataReader["Specialization"].ToString()
                            };
                            sml.Add(sm);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return sml;
        }

        public bool specAlreadyExists(SpecializationModel sm)
        {
            string query = $"SELECT [OId] ,[Specialization] FROM [Hospital].[dbo].[Specialization] where [Specialization]='{sm.Specialiaztion}'";
            _logger.LogInformation("Entered in SpecializationAlreadyExists..");
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
                        _logger.LogInformation("Specialization Already Exist..");
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
    }
}
