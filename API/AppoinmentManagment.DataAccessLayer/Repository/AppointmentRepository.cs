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
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly ILogger<AppointmentRepository> _logger;
        private readonly IConfiguration _config;
        private readonly IUserRepository _user;
        private readonly IDoctorRepository _doctor;

        public AppointmentRepository(ILogger<AppointmentRepository> logger, IConfiguration config, IUserRepository user, IDoctorRepository doctor)
        {
            _logger = logger;
            _config = config;
            _user = user;
            _doctor = doctor;
        }

        public int Add(AppoinmentBO abo, int id, string name, string appointId)
        {
            string Query = $"INSERT INTO [dbo].[Appoinment]([AppointId],[PatientId],[DoctorId],[AppointmentDate],[AppointmentTime],[AppointmentStatus],[Symptom],[Medication],[IsVisited],[IsPaid],[IsPrescribed],[Created_at],[Created_by])" +
                            $"VALUES('{appointId}','{id}','{abo.DoctorId}','{abo.AppointmentDate}','{abo.AppointmentTime}','Pending','{abo.Symptom}','{abo.Medication}',0,0,0, GetDate(),'{name}')";

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

        public bool AppointmentAlreadyExists(AppoinmentBO abo, int id)
        {
            string query = $"SELECT  [AppointId] FROM [Hospital].[dbo].[Appoinment] WHERE [PatientId] = '{id}' AND [DoctorId] = '{abo.DoctorId}'AND [AppointmentDate] = '{abo.AppointmentDate}'AND [AppointmentStatus] = 'Pending' OR [AppointmentStatus] = 'Active'";
            _logger.LogInformation("Entered in AppointmentAlreadyExists..");
            bool flag = false;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                try
                {
                    connection.Open();
                    string sql = query;
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        flag = true;
                        _logger.LogInformation("Appointment Already Exist..");
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

        public int ApproveAppoinment(string id, string name)
        {
            string Query = $"UPDATE [dbo].[Appoinment] SET[AppointmentStatus] = 'Approved' ,[Updated_at] = GETDATE() ,[Updated_by] = '{name}' WHERE[AppointId] = '{id}'";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Updated");
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

        public int CountPendingAppointment(string id)
        {
            string query = $"SELECT COUNT([AppointId])as appoint FROM [Hospital].[dbo].[Appoinment] WHERE[AppointmentStatus] = 'Pending' AND [DoctorId] = '{id}'; ";
            int result = 0;
            _logger.LogInformation("Getting pending appoinent count..");

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
                            result = Convert.ToInt32(dataReader["appoint"]);
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

        public int DeclineAppoinment(string id, string name)
        {
            string Query = $"UPDATE [dbo].[Appoinment] SET[AppointmentStatus] = 'Declined' ,[Updated_at] = GETDATE() ,[Updated_by] = '{name}' WHERE[AppointId] = '{id}'";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Updated");
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

        public List<AppoinmentBO> GetAllPendingAppoinmentByDrId(string DrId)
        {
            List<AppoinmentBO> abol = new List<AppoinmentBO>();
            string Query = $"SELECT [AppointId],[DoctorId],[PatientId],[AppointmentDate],[AppointmentTime],[AppointmentStatus],[Symptom],[Medication] FROM [Hospital].[dbo].[Appoinment]  where [DoctorId] = '{DrId}' AND [AppointmentStatus] = 'Pending'";
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
                            AppoinmentBO abo = new AppoinmentBO
                            {
                                AppointmentId = dataReader["AppointId"].ToString(),
                                PatientName = _user.GetUserName(Convert.ToInt32(dataReader["PatientId"])).ToString(),
                                DoctorName = _doctor.GetDoctorName(dataReader["DoctorId"].ToString()).ToString(),
                                AppointmentDate = Convert.ToDateTime(dataReader["AppointmentDate"]).ToString("dd/MM/yyyy"),
                                AppointmentTime = dataReader["AppointmentTime"].ToString(),
                                Medication = dataReader["Medication"].ToString(),
                                Symptom = dataReader["Symptom"].ToString(),
                                AppointmentStatus = dataReader["AppointmentStatus"].ToString()
                            };
                            abol.Add(abo);
                            
                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }
                    
                    return abol;
                }
                catch(Exception e)
                {
                    _logger.LogWarning($"'{e}' Exception");
                    connection.Close();
                    return null;
                }
                   
            }
            catch(Exception e)
            {
                _logger.LogWarning($"'{e}' Exception");
                connection.Close();
                return null;
            }
            
        }

        public AppoinmentBO GetAppoinmentById(string id)
        {
            AppoinmentBO abo = new AppoinmentBO();
            string Query = $"SELECT [AppointId],[DoctorId],[PatientId],[Symptom],[Medication],[Diesis],[Prescription] FROM[Hospital].[dbo].[Appoinment] WHERE [AppointId] = '{id}' ";
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

                            abo.AppointmentId = dataReader["AppointId"].ToString();
                            abo.PatientName = _user.GetUserName(Convert.ToInt32(dataReader["PatientId"])).ToString();
                            abo.DoctorName = _doctor.GetDoctorName(dataReader["DoctorId"].ToString()).ToString();
                            abo.Diesis = dataReader["Diesis"].ToString();
                            abo.Medication = dataReader["Medication"].ToString();
                            abo.Prescription = dataReader["Prescription"].ToString();
                            abo.Symptom = dataReader["Symptom"].ToString();

                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }

                    return abo;
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

        public string GetAppointedDoctorId(string id)
        {
            
            string query = $"SELECT[DoctorId]  FROM[Hospital].[dbo].[Appoinment]  Where[AppointId] = '{id}'";
            string DrId = "";

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
                            DrId = dataReader["DoctorId"].ToString();
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        _logger.LogWarning($"'{e}' Exception");
                    }
                }
                connection.Close();
            }
            return DrId;
        }

        public List<AppoinmentBO> GetApprovedPaidAppointmentDoctorId(string DrId)
        {
            List<AppoinmentBO> abol = new List<AppoinmentBO>();
            string Query = $"SELECT [AppointId],[PatientId],[AppointmentDate],[AppointmentTime],[AppointmentStatus],[IsVisited],[IsPaid],[IsPrescribed] FROM[Hospital].[dbo].[Appoinment] WHERE[AppointmentStatus] = 'Approved' AND [DoctorId] = '{DrId}' AND [IsPaid] = 1 ";
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
                            AppoinmentBO abo = new AppoinmentBO
                            {
                                AppointmentId = dataReader["AppointId"].ToString(),
                                PatientName = _user.GetUserName(Convert.ToInt32(dataReader["PatientId"])).ToString(),
                                AppointmentDate = Convert.ToDateTime(dataReader["AppointmentDate"]).ToString("dd/MM/yyyy"),
                                AppointmentTime = dataReader["AppointmentTime"].ToString(),
                                AppointmentStatus = dataReader["AppointmentStatus"].ToString(),
                                IsVisited = Convert.ToInt32(dataReader["IsVisited"]),
                                IsPaid = Convert.ToInt32(dataReader["IsPaid"]),
                                IsPrescribed = Convert.ToInt32(dataReader["IsPrescribed"])

                            };
                            abol.Add(abo);

                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }

                    return abol;
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

        public List<AppoinmentBO> GetApprovedAppointmentPatientId(int id)
        {
            List<AppoinmentBO> abol = new List<AppoinmentBO>();
            string Query = $"SELECT [AppointId],[DoctorId],[AppointmentDate],[AppointmentTime],[AppointmentStatus],[IsVisited],[IsPaid],[IsPrescribed] FROM[Hospital].[dbo].[Appoinment] WHERE[AppointmentStatus] = 'Approved' OR [AppointmentStatus] = 'Pending' AND[PatientId] = '{id}' AND[IsPaid] = 0";
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
                            AppoinmentBO abo = new AppoinmentBO
                            {
                                AppointmentId = dataReader["AppointId"].ToString(),
                                DoctorName = _doctor.GetDoctorName(dataReader["DoctorId"].ToString()).ToString(),
                                AppointmentDate = Convert.ToDateTime(dataReader["AppointmentDate"]).ToString("dd/MM/yyyy"),
                                AppointmentTime = dataReader["AppointmentTime"].ToString(),
                                AppointmentStatus = dataReader["AppointmentStatus"].ToString(),
                                IsVisited = Convert.ToInt32(dataReader["IsVisited"]),
                                IsPaid = Convert.ToInt32(dataReader["IsPaid"]),
                                IsPrescribed = Convert.ToInt32(dataReader["IsPrescribed"])
                                
                            };
                            abol.Add(abo);

                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }

                    return abol;
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

        public int Prescribe(string id, string prescription, string desis, string name)
        {
            string Query = $"UPDATE [dbo].[Appoinment] SET [Diesis] ='{desis}',[Prescription] ='{prescription}',[IsPrescribed] = '{1}' ,[Updated_at] = GETDATE() ,[Updated_by] = '{name}' WHERE[AppointId] = '{id}'";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Updated");
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

        public int UpdateAppointmentPayment(string id, string name)
        {
            string Query = $"UPDATE [dbo].[Appoinment] SET[IsPaid] = 1 ,[Updated_at] = GETDATE() ,[Updated_by] = '{name}' WHERE [AppointId] = '{id}'";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Updated");
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

        public int VisitAppointment(string id, string name)
        {
            string Query = $"UPDATE [dbo].[Appoinment] SET[IsVisited] = '{1}' ,[Updated_at] = GETDATE() ,[Updated_by] = '{name}' WHERE[AppointId] = '{id}'";
            int Result;
            string connectionString = _config["ConnectionStrings:DefaultConnection"];
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string sql = Query;
                SqlCommand command = new SqlCommand(sql, connection);
                Result = command.ExecuteNonQuery();
                _logger.LogInformation("Data Updated");
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

        public List<AppoinmentBO> GetAllApprovedAppoinmentByDrId(string DrId)
        {
            List<AppoinmentBO> abol = new List<AppoinmentBO>();
            string Query = $"SELECT [AppointId],[DoctorId],[PatientId],[AppointmentDate],[AppointmentTime],[AppointmentStatus],[Symptom],[Medication] FROM [Hospital].[dbo].[Appoinment]  where [DoctorId] = '{DrId}' AND [AppointmentStatus] = 'Approved'";
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
                            AppoinmentBO abo = new AppoinmentBO
                            {
                                AppointmentId = dataReader["AppointId"].ToString(),
                                PatientName = _user.GetUserName(Convert.ToInt32(dataReader["PatientId"])).ToString(),
                                DoctorName = _doctor.GetDoctorName(dataReader["DoctorId"].ToString()).ToString(),
                                AppointmentDate = Convert.ToDateTime(dataReader["AppointmentDate"]).ToString("dd/MM/yyyy"),
                                AppointmentTime = dataReader["AppointmentTime"].ToString(),
                                Medication = dataReader["Medication"].ToString(),
                                Symptom = dataReader["Symptom"].ToString(),
                                AppointmentStatus = dataReader["AppointmentStatus"].ToString()
                            };
                            abol.Add(abo);

                        }
                        dataReader.Close(); // <- too easy to forget
                        dataReader.Dispose();
                        connection.Close();
                    }

                    return abol;
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
    }
}
