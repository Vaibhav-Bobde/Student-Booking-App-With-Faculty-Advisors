using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ServiceLayer.Interface;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IFacultyService _facultyService;
        public AdminController(IDepartmentService departmentService, IFacultyService facultyService, IMapper mapper)
            :base(mapper)
        {
            this._departmentService = departmentService;
            this._facultyService = facultyService;
        }
        [HttpGet]
        public ActionResult Admin()
        {
            IList<Department> departments = _mapper.Map<IList<Department>>(_departmentService.FetchAllDepartments());
            return View(_mapper.Map<IList<Department>>(departments));
        }
        [HttpGet]
        public JsonResult EnableOrDisableFacultySchedule(int facultyId, bool isSchEditEnabled)
        {
            bool status = _facultyService.EnableOrDisableFacultySchedule(facultyId, isSchEditEnabled);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
