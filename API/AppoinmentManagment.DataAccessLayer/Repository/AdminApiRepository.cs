using AppoinmentManagment.BusinessLayer;
using AppoinmentManagment.DataAccessLayer.IRepository;
using AppoinmentManagment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.Repository
{
    public class AdminApiRepository : IAdminApiRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AdminApiRepository> _logger;

        public AdminApiRepository(IConfiguration config, ILogger<AdminApiRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public int CountPatient()
        {
            string query = $"SELECT COUNT([OId])as patient FROM[Hospital].[dbo].[User] WHERE[TypeId] = 2; ";
            int result = 0;
            _logger.LogInformation("Getting patient count..");

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
                            result = Convert.ToInt32(dataReader["patient"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return result;
        }

        public int CountDoctor()
        {
            string query = $"SELECT COUNT([OId])as doctor FROM[Hospital].[dbo].[User] WHERE[TypeId] = 3; ";
            int result = 0;
            _logger.LogInformation("Getting Doctor count..");

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
                            result = Convert.ToInt32(dataReader["doctor"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return result;
        }

        public int CountSpecialization()
        {
            string query = $"SELECT COUNT(*) as special FROM [Hospital].[dbo].[Specialization] ";
            int result = 0;
            _logger.LogInformation("Getting Specialization count..");

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
                            result = Convert.ToInt32(dataReader["special"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return result;
        }

        public int TotalBalance()
        {
            string query = $"SELECT [Balance] FROM [Hospital].[dbo].[Company] ";
            int result = 0;
            _logger.LogInformation("Getting Company Balance count..");

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
                            result = Convert.ToInt32(dataReader["Balance"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return result;
        }

        public List<UserBO> GetAllPatientList()
        {
            string query = $"SELECT  [OId],[TypeId],[Name],[Address],[Gender],[DOB],[Phone],[Email],[Password] FROM[Hospital].[dbo].[User] WHERE[TypeId] = 2";
            List<UserBO> ubol = new List<UserBO>();
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) //make it single user
                    {
                        try
                        {
                            if (dataReader != null)
                            {
                                UserBO ubo = new UserBO()
                                {
                                    OId = Convert.ToInt32(dataReader["OId"]),
                                    Name = dataReader["Name"].ToString(),
                                    Phone = dataReader["Phone"].ToString(),
                                    Address = dataReader["Address"].ToString(),
                                    DOB = dataReader["DOB"].ToString(),
                                };
                                ubol.Add(ubo);
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            _logger.LogError($"'{e}' Exception");
                        }
                    }
                }
                connection.Close();
            }

            //UserBO obj = new UserBO
            //{
            //    UserList = ubol
            //};

            return ubol;
        }

        public List<MonthlyDepositBO> GetMonthlyDeposit()
        {
            string query = "SELECT CASE { fn MONTH([Created_at]) } " +
            "when 1 then 'January' when 2 then 'February' when 3 then 'March' when 4 then 'April' when 5 then 'May'" +
            "when 6 then 'June'  when 7 then 'July' when 8 then 'August' when 9 then 'September' when 10 then 'October'"+
            "when 11 then 'November' when 12 then 'December' END AS _Month , SUM([Amount])AS Total FROM[Hospital].[dbo].[Transaction] WHERE datepart(yy, [Created_at]) = year(GetDate())" +
            " GROUP BY  { fn MONTH([Created_at]) } ORDER BY  { fn MONTH([Created_at]) }";
            List<MonthlyDepositBO> mdbol = new List<MonthlyDepositBO>();
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = query;
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) //make it single user
                    {
                        try
                        {
                            if (dataReader != null)
                            {
                                MonthlyDepositBO mdbo = new MonthlyDepositBO()
                                {
                                    Amount  = Convert.ToDecimal(dataReader["Total"]),
                                    Month = dataReader["_Month"].ToString()
                                };
                                mdbol.Add(mdbo);
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            _logger.LogError($"'{e}' Exception");
                        }
                    }
                }
                connection.Close();
            }

            return mdbol;
        }


        public List<Monthly> GetYearlyDeposit()
        {
            List<YearlyDepositBO> cmvmlist = new List<YearlyDepositBO>();
            var query = "SELECT CASE { fn MONTH([Created_at]) } "+
            "when 1 then 'January' when 2 then 'February' when 3 then 'March' when 4 then 'April' when 5 then 'May' when 6 then 'June'  when 7 then 'July' when 8 then 'August' when 9 then 'September' when 10 then 'October'" +
            " when 11 then 'November' when 12 then 'December' END AS _Month , SUM([Amount])AS Total, DATENAME(yy, [Created_at]) AS _Year FROM[Hospital].[dbo].[Transaction] WHERE[Created_at] >= DATEADD(year, -5, GETDATE())  GROUP BY  { fn MONTH([Created_at]) },DATENAME(yy, [Created_at]) ORDER BY  { fn MONTH([Created_at]) },DATENAME(yy, [Created_at])";
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
                            YearlyDepositBO ywvm = new YearlyDepositBO
                            {
                                Total = Convert.ToDecimal(dataReader["Total"]),
                                Year = dataReader["_Year"].ToString(),
                                Month = dataReader["_Month"].ToString()
                            };

                            cmvmlist.Add(ywvm);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            List<Monthly> remarkList = new List<Monthly>();

            var remarks = cmvmlist.Select(c => c.Month).Distinct().ToList();

            foreach (var r in remarks)
            {
                Monthly remark = new Monthly
                {
                    Month = r,
                    List = cmvmlist.FindAll(x => x.Month == r)
                };
                remarkList.Add(remark);
            }
            return remarkList;
        }
    }
}
