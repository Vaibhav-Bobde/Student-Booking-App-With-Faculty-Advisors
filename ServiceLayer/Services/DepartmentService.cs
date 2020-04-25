using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Interface;
using ServiceLayer.Models;
namespace ServiceLayer.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public IList<Department> FetchAllDepartments()
        {
            return base._mapper.Map<IList<Department>>(facAppDataRepo.FetchAllDepartments());
        }
    }
}
