using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }
        protected virtual new CustomPrincipal User
        {
                get { return HttpContext.User as CustomPrincipal; }
        }
        
    }
}