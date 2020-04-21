using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BaseService
    {
        public FacultyAppDataRepository facAppDataRepo;
        public IMapper _mapper;
        public BaseService()
        {
            facAppDataRepo = new FacultyAppDataRepository();            
            _mapper = AutoMapperServiceProfile.Init();
        }
    }
}
