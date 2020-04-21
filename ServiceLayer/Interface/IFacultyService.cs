using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceLayer.Models;

namespace ServiceLayer.Interface
{
    public interface IFacultyService
    {
        Faculty FetchFaculty(string fname, string lname);
        bool UpdateSchedule(IList<Schedule> lstSchedule);
        IList<Schedule> FetchSchedule(int facultyId);
    }
}
