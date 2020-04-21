using System;
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
        public Faculty FetchFaculty(string fname, string lname)
        {
            Faculty faculty = facAppData.Faculties.Where(w => w.Fname.Equals(fname) && w.Lname.Equals(lname)).DefaultIfEmpty(null).FirstOrDefault();
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
    }
}
