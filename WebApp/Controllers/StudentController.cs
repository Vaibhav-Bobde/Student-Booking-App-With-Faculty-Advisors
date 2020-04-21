using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController(IMapper mapper)
            :base(mapper)
        {

        }
        public ActionResult SetAppointment()
        {
            return View();
        }
    }
}
