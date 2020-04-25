using System;
using System.Collections.Generic;
using System.Linq;
using ServiceLayer.Interface;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class AppointmentService : BaseService, IAppointmentService
    {
        public bool SaveAppointment(Appointment appointment)
        {
            return facAppDataRepo.SaveAppointment(_mapper.Map<DAL.Appointment>(appointment));
        }
        public Student FetchStudentBasedOnUserId(int userId)
        {
            return _mapper.Map<Student>(facAppDataRepo.FetchStudentBasedOnUserId(userId));
        }
        public IList<Appointment> FetchAvailAppointmentTimeSlots(int facultyId, DateTime selDate, out bool isFacultyUnAvaillable)
        {
            DAL.Schedule schedule = facAppDataRepo.FetchScheduleForDayOfWeekOfFaculty(facultyId, selDate.DayOfWeek.ToString());            
            IList<Appointment> availAppointments = new List<Appointment>();
            if (schedule == null || schedule.IsUnavailableEntireDay)
            {
                isFacultyUnAvaillable = true;
                return availAppointments;
            }
            isFacultyUnAvaillable = schedule.IsUnavailableEntireDay;
            IList<DAL.Appointment> bookedAppointments = facAppDataRepo.FetchScheduledAppointments(facultyId, selDate);
            TimeSpan? startTime = schedule.AvailableFromTime;
            TimeSpan? endTime = schedule.AvailableTillTime;
            if (bookedAppointments.Count == 0)
            {
                DateTime tempStartDate = (selDate.Date + schedule.AvailableFromTime) ?? DateTime.Now;
                DateTime tempEndDate = (selDate.Date + schedule.AvailableTillTime) ?? DateTime.Now;
                availAppointments.Add(new Appointment() { StartTime = tempStartDate, EndTime = tempEndDate });
            }
            else
            {
                //for (int i = 0; i < bookedAppointments.Count; i++)
                //{
                //    while (i < bookedAppointments.Count && startTime == bookedAppointments[i].StartTime.TimeOfDay)
                //    {
                //        startTime = startTime.Value.Add(TimeSpan.FromMinutes(30));
                //        i++;
                //    }
                //    if (i < bookedAppointments.Count && startTime < bookedAppointments[i].StartTime.TimeOfDay)
                //    {
                //        DateTime tempDate = (selDate.Date + startTime) ?? DateTime.Now;
                //        availAppointments.Add(new Appointment() { StartTime = tempDate, EndTime = bookedAppointments[i].StartTime });
                //    }
                //}
                for (int i = 0; i < bookedAppointments.Count; )
                {
                    if (startTime < bookedAppointments[i].StartTime.TimeOfDay)
                    {
                        DateTime tempDate = (selDate.Date + startTime) ?? DateTime.Now;
                        availAppointments.Add(new Appointment() { StartTime = tempDate, EndTime = bookedAppointments[i].StartTime });
                        startTime = bookedAppointments[i].StartTime.TimeOfDay;
                    }
                    else
                    {
                        startTime = bookedAppointments[i].EndTime.TimeOfDay;
                        i++;
                    }
                }
                if (startTime < schedule.AvailableTillTime)
                {
                    DateTime tempStartDate = (selDate.Date + startTime) ?? DateTime.Now;
                    DateTime tempEndDate = (selDate.Date + schedule.AvailableTillTime) ?? DateTime.Now;
                    availAppointments.Add(new Appointment() { StartTime = tempStartDate, EndTime = tempEndDate });
                }               
            }
            return availAppointments;
        }
        public IList<Appointment> FetchPreviousAppointmentsOfStudent(int studentId)
        {
            return _mapper.Map<IList<Appointment>>(facAppDataRepo.FetchPreviousAppointmentsOfStudent(studentId));
        }
        public bool CancelAppointment(int appointmentId)
        {
            return facAppDataRepo.CancelAppointment(appointmentId);
        }
    }
}
