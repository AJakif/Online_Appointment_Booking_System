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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ILogger<CompanyRepository> _logger;
        private readonly IConfiguration _config;

        public CompanyRepository(ILogger<CompanyRepository> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public CompanyModel GetInfo()
        {
            string query = $"SELECT [OId],[Name],[Address],[Balance] FROM[Hospital].[dbo].[Company]";

            _logger.LogInformation("Entered in Get info Company..");
            CompanyModel cmp = new CompanyModel();

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
                            cmp.Name = dataReader["Name"].ToString();
                            cmp.Address = dataReader["Address"].ToString();
                            cmp.Balance = Convert.ToDecimal(dataReader["Balance"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return cmp;
        }
    }
}
