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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PaymentRepository> _logger;
        private readonly IAppointmentRepository _appoint;

        public PaymentRepository(IConfiguration config, ILogger<PaymentRepository> logger, IAppointmentRepository appoint)
        {
            _config = config;
            _logger = logger;
            _appoint = appoint;
        }

        public int AddTransaction(ListAppoinmentBO listabo, string trasid, int userid, string drid,string name)
        {
            string Query = "INSERT INTO [dbo].[Transaction]([TransId],[PatientId],[DoctorId],[AppointmentId],[Amount],[Created_at],[Created_by])" +
                $"VALUES('{trasid}','{userid}','{drid}','{listabo.Appointment.AppointmentId}','{listabo.Transaction.Amount}',GetDate(),'{name}')";
            
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

        public decimal GetDoctorFeesById(string id)
        {
            string DrId = _appoint.GetAppointedDoctorId(id);

            string query = $"SELECT[Fee]  FROM[Hospital].[dbo].[Doctor]  Where DrId = '{DrId}'";
            decimal fee = 0;

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
                            fee = Convert.ToDecimal(dataReader["Fee"]);
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return fee;
        }

    }
}
