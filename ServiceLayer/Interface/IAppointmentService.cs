using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.Interface
{
    public interface IAppointmentService
    {
        bool SaveAppointment(Appointment appointment);
        Student FetchStudentBasedOnUserId(int userId);
        IList<Appointment> FetchAvailAppointmentTimeSlots(int facultyId, DateTime selDate, out bool isFacultyUnAvaillable);
        IList<Appointment> FetchPreviousAppointmentsOfStudent(int studentId);
        IList<Appointment> FetchPreviousAppointmentsOfFaculty(int studentId);
        bool CancelAppointment(int appointmentId);
    }
}
