using AutoMapper;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class FacultyController : BaseController
    {
        private readonly IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService, IMapper mapper)
            : base(mapper)
        {
            this._facultyService = facultyService;
        }
        [HttpGet]
        public ActionResult GetFacultySchedule()
        {
            Faculty faculty = base._mapper.Map<ServiceLayer.Models.Faculty, Faculty>(_facultyService.FetchFaculty(User.Id));
            IList<Schedule> schedules = _mapper.Map<IList<ServiceLayer.Models.Schedule>, IList<Schedule>>(_facultyService.FetchSchedule(faculty.FacultyId));
            ViewBag.FacultyId = faculty.FacultyId;
            return View(schedules);
        }
        [HttpPost]
        public JsonResult UpdateFacultySchedule(IList<Models.Schedule> lstSchedule)
        {
            IList<ServiceLayer.Models.Schedule> schedules = _mapper.Map<IList<Schedule>, IList<ServiceLayer.Models.Schedule>>(lstSchedule);
            bool success = _facultyService.UpdateSchedule(schedules);
            return Json(success);
        }
    }
}
