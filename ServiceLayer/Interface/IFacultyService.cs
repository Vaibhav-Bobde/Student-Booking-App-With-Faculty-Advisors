using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IFacultyService
    {
        IList<Faculty> FetchAllFacultiesOfDepartment(int deptId);
        bool EnableOrDisableFacultySchedule(int facultyId, bool isSchEditEnabled);
    }
}
