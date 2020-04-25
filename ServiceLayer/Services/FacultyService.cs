using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
namespace ServiceLayer.Services
{
    public class FacultyService : BaseService, IFacultyService
    {
        public IList<Faculty> FetchAllFacultiesOfDepartment(int deptId)
        {
            return _mapper.Map<IList<Faculty>>(facAppDataRepo.FetchAllFacultiesOfDepartment(deptId));
        }
    }
}
