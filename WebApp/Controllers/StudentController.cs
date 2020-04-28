using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Interface;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IFacultyService _facultytService;
        private readonly IScheduleService _scheduletService;
        private readonly IAppointmentService _appointmentService;
        public StudentController(IMapper mapper, IDepartmentService departmentService, IFacultyService facultytService, IScheduleService scheduletService, IAppointmentService appointmentService)
            :base(mapper)
        {
            this._departmentService = departmentService;
            this._facultytService = facultytService;
            this._scheduletService = scheduletService;
            this._appointmentService = appointmentService;
        }
        public ActionResult StudentAppointment()
        {
            IList<Department> departments = _mapper.Map<IList<Department>>(_departmentService.FetchAllDepartments());
            return View(departments);
        }
        [HttpGet]
        public JsonResult FetchFacultiesOfDepartment(int deptId)
        {
            return Json(_mapper.Map<IList<Faculty>>(_facultytService.FetchAllFacultiesOfDepartment(deptId)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult FetchAvailAppointmentTimeSlots(int facultyId, DateTime selDate)
        {
            bool IsFacultyUnAvailable;
            IList<Appointment> availAppointments = _mapper.Map<IList<Appointment>>(_appointmentService.FetchAvailAppointmentTimeSlots(facultyId, selDate, out IsFacultyUnAvailable));
            if(IsFacultyUnAvailable)
                return Json("Faculty Unavailable", JsonRequestBehavior.AllowGet);
            return Json(availAppointments, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MakeAppointment(Appointment appointment)
        {            
            Student student = _mapper.Map<Student>(_appointmentService.FetchStudentBasedOnUserId(User.Id));
            if(student == null)
                return Json("error");
            appointment.StudentId = student.StudentId;
            bool status = _appointmentService.SaveAppointment(_mapper.Map<ServiceLayer.Models.Appointment>(appointment));
            return Json(status ? "success" : "You are already on Waitlist.");
        }        
        [HttpGet]
        public ActionResult PreviousAppointments()
        {
            Student student = _mapper.Map<Student>(_appointmentService.FetchStudentBasedOnUserId(User.Id));
            IList<Appointment> appointments = _mapper.Map<IList<Appointment>>(this._appointmentService.FetchPreviousAppointmentsOfStudent(student.StudentId));
            appointments = appointments ?? new List<Appointment>();
            return View("PreviousAppointments", appointments);
        }
        [HttpGet]
        public JsonResult CancelAppointment(int appointmentId)
        {
            bool status = this._appointmentService.CancelAppointment(appointmentId);
            string msg = status ? "success" : "error";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}
