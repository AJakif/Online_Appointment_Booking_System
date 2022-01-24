using AppoinmentManagment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppoinmentManagment.DataAccessLayer.IRepository
{
    public interface IAppointmentRepository
    {
        bool AppointmentAlreadyExists(AppoinmentBO abo, int id);
        int Add(AppoinmentBO abo, int id, string name, string appointId);

        AppoinmentBO GetAppoinmentById(string id);

        List<AppoinmentBO> GetAllPendingAppoinmentByDrId(string DrId);
        List<AppoinmentBO> GetAllApprovedAppoinmentByDrId(string DrId);

        int DeclineAppoinment(string id, string name);
        int ApproveAppoinment(string id, string name);
        int VisitAppointment(string id, string name);

        int Prescribe(string id, string prescription, string desis, string name);

        int CountPendingAppointment(string id);

        List<AppoinmentBO> GetApprovedAppointmentPatientId(int id);
        List<AppoinmentBO> GetApprovedPaidAppointmentDoctorId(string DrId);

        string GetAppointedDoctorId(string id);

        int UpdateAppointmentPayment(string id, string name);
    }
}
