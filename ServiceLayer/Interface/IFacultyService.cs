using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayer.Models;

namespace ServiceLayer.Interface
{
    public interface IScheduleService
    {
        Faculty FetchFaculty(int userId);
        bool UpdateSchedule(IList<Schedule> lstSchedule);
        IList<Schedule> FetchSchedule(int facultyId);
    }
}
