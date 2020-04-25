using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayer.Interface;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class ScheduleService : BaseService, IScheduleService
    {
        public Faculty FetchFaculty(int userId)
        {
            DAL.Faculty faculty = base.facAppDataRepo.FetchFaculty(userId);
            return _mapper.Map<DAL.Faculty, Faculty>(faculty);
        }
        public bool UpdateSchedule(IList<Schedule> lstSchedule)
        {
            IList<DAL.Schedule> schedules = _mapper.Map<IList<Schedule>, IList<DAL.Schedule>>(lstSchedule);
            return base.facAppDataRepo.UpdateSchedule(schedules);
        }
        public IList<Schedule> FetchSchedule(int facultyId)
        {
            IList<Schedule> schedules = _mapper.Map<IList<DAL.Schedule>, IList<Schedule>>(base.facAppDataRepo.FetchSchedule(facultyId));
            if(!schedules.Any())
            {
                string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                foreach (var day in days)
                {
                    schedules.Add(new Schedule()
                    {
                        FacultyId = facultyId,
                        Day = day
                    });
                }
            }
            return schedules;
        }        
    }
}
