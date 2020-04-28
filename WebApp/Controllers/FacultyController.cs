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
        private readonly IScheduleService _scheduleService;
        private readonly IAppointmentService _appointmentService;
        public FacultyController(IScheduleService scheduleService, IAppointmentService appointmentService, IMapper mapper)
            : base(mapper)
        {
            this._scheduleService = scheduleService;
            this._appointmentService = appointmentService;
        }
        [HttpGet]
        public ActionResult GetFacultySchedule()
        {
            Faculty faculty = base._mapper.Map<ServiceLayer.Models.Faculty, Faculty>(_scheduleService.FetchFaculty(User.Id));
            IList<Schedule> schedules = _mapper.Map<IList<ServiceLayer.Models.Schedule>, IList<Schedule>>(_scheduleService.FetchSchedule(faculty.FacultyId));
            ViewBag.FacultyId = faculty.FacultyId;
            ViewBag.IsFacultySchEnabled = faculty.IsScheduleEditEnabled;
            return View(schedules);
        }
        [HttpPost]
        public JsonResult UpdateFacultySchedule(IList<Models.Schedule> lstSchedule)
        {
            IList<ServiceLayer.Models.Schedule> schedules = _mapper.Map<IList<Schedule>, IList<ServiceLayer.Models.Schedule>>(lstSchedule);
            bool success = _scheduleService.UpdateSchedule(schedules);
            return Json(success);
        }
        [HttpGet]
        public ActionResult PreviousAppointments()
        {
            Faculty faculty = base._mapper.Map<ServiceLayer.Models.Faculty, Faculty>(_scheduleService.FetchFaculty(User.Id));
            IList<Appointment> appointments = _mapper.Map<IList<Appointment>>(this._appointmentService.FetchPreviousAppointmentsOfFaculty(faculty.FacultyId));
            appointments = appointments ?? new List<Appointment>();
            return View("PreviousAppointments", appointments);
        }
    }
}
