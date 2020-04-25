﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FacultyAppDataRepository
    {
        public FacultyAppDataRepository()
        {
            //Database.SetInitializer<MyContext>(null);
        }
        public FacultyAppData facAppData = new FacultyAppData();
        public User GetUser(string email, string pwd)
        {
            User user = facAppData.Users.Where(a => a.EmailId.Equals(email) && a.Pwd.Equals(pwd)).DefaultIfEmpty(null).FirstOrDefault() as DAL.User;
            user.UserRole = facAppData.UserRoles.Where(r => r.RoleId == user.RoleId).Single();
            return user;
        }
        public Faculty FetchFaculty(int userId)
        {
            Faculty faculty = facAppData.Faculties.Where(w => w.Uid == userId).DefaultIfEmpty(null).FirstOrDefault();
            return faculty;
        }
        public bool UpdateSchedule(IList<Schedule> newSchedules)
        {
            int facultyId = newSchedules.First().FacultyId;
            var prevSchedules = facAppData.Schedules.Where(w => w.FacultyId == facultyId);
            if (prevSchedules.Any())
            {
                foreach (var prevSchedule in prevSchedules)
                {
                    var newSchedule = newSchedules.SingleOrDefault(a => a.Day.Equals(prevSchedule.Day));
                    prevSchedule.AvailableFromTime = newSchedule.AvailableFromTime;
                    prevSchedule.AvailableTillTime = newSchedule.AvailableTillTime;
                    prevSchedule.IsUnavailableEntireDay = newSchedule.IsUnavailableEntireDay;
                }
            }
            else
            {
                foreach (var schedule in newSchedules)
                {
                    facAppData.Schedules.Add(schedule);
                }
            }
            facAppData.SaveChanges();
            return true;
        }
        public IList<Schedule> FetchSchedule(int facultyId)
        {
            return facAppData.Schedules.Where(w => w.FacultyId == facultyId).ToList();
        }

        public IList<Department> FetchAllDepartments()
        {
            return facAppData.Departments.ToList();
        }

        public IList<Faculty> FetchAllFacultiesOfDepartment(int deptId)
        {
            IList<Faculty> faculties =  facAppData.Faculties.Where(a => a.DeptId == deptId).ToList();
            foreach (var faculty in faculties)
            {
                faculty.User = facAppData.Users.Where(a => a.Uid == faculty.Uid).FirstOrDefault();
            }
            return faculties;
        }
        public Schedule FetchScheduleForDayOfWeekOfFaculty(int facultyId, string dayOfWeek)
        {
            return facAppData.Schedules.Where(a => a.FacultyId == facultyId && a.Day == dayOfWeek && !a.IsUnavailableEntireDay).FirstOrDefault();
        }
        public IList<Appointment> FetchScheduledAppointments(int facultyId, DateTime selDate)
        {
            return facAppData.Appointments.Where( j => j.FacultyId == facultyId
                                   && j.StartTime.Year == selDate.Year
                                   && j.StartTime.Month == selDate.Month
                                   && j.StartTime.Day == selDate.Day
                                   && j.IsOnWaitList == false).OrderBy(o => o.StartTime).ToList();            
        }
        public Student FetchStudentBasedOnUserId(int userId)
        {
            return facAppData.Students.Where(a => a.Uid == userId).FirstOrDefault();
        }
        public bool SaveAppointment(Appointment appointment)
        {
            var existingWaitListAppointment = facAppData.Appointments.Where(j => j.FacultyId == appointment.FacultyId
                                  && j.StudentId == appointment.StudentId
                                  && j.StartTime.Year == appointment.StartTime.Year
                                  && j.StartTime.Month == appointment.StartTime.Month
                                  && j.StartTime.Day == appointment.StartTime.Day
                                  && j.IsOnWaitList == true).FirstOrDefault();
            if(existingWaitListAppointment != null)
            {
                if(appointment.IsOnWaitList)
                {
                    return false;
                }
                facAppData.Appointments.Remove(existingWaitListAppointment);
            }
            facAppData.Appointments.Add(new Appointment()
            {
                FacultyId = appointment.FacultyId,
                StudentId = appointment.StudentId,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                AppointmentHappened = appointment.AppointmentHappened,
                IsOnWaitList = appointment.IsOnWaitList
            });
            facAppData.SaveChanges();
            return true;
        }
        public bool AddToWaitList(Appointment appointment)
        {
            var existingWaitListAppointment = facAppData.Appointments.Where(j => j.FacultyId == appointment.FacultyId
                                  && j.StudentId == appointment.StudentId
                                  && j.StartTime.Year == appointment.StartTime.Year
                                  && j.StartTime.Month == appointment.StartTime.Month
                                  && j.StartTime.Day == appointment.StartTime.Day).FirstOrDefault();
            if (existingWaitListAppointment != null)
                return false;
            else
                return true;
        }
        public IList<Appointment> FetchPreviousAppointmentsOfStudent(int studentId)
        {
            var currDate = DateTime.Now;
            IList<Appointment> appointments = facAppData.Appointments.Where(a => a.StudentId == studentId 
                                    && a.StartTime.Year >= currDate.Year
                                    && a.StartTime.Month >= currDate.Month
                                    && a.StartTime.Day >= currDate.Day
                                    && a.AppointmentHappened == false).ToList();
            foreach (var appointment in appointments)
            {
                appointment.Faculty = facAppData.Faculties.Where(a => a.FacultyId == appointment.FacultyId).FirstOrDefault();
                appointment.Faculty.User =  facAppData.Users.Where(a => a.Uid == appointment.Faculty.Uid).FirstOrDefault();
            }
            return appointments;
        }
        public bool CancelAppointment(int appointmentId)
        {
            var appointment = facAppData.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefault();
            facAppData.Appointments.Remove(appointment);            
            facAppData.SaveChanges();
            return true;
        }
    }
}
