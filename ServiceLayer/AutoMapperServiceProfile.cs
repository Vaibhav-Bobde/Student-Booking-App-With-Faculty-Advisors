using AutoMapper;
using AutoMapper.Configuration;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AutoMapperServiceProfile : AutoMapper.Profile
    {
        private static Mapper _mapper;
        /// <summary>
        /// Custom method to Initialize and return Singleton Mapper Object with AutoMapperServiceProfile.
        /// </summary>
        /// <returns></returns>
        public static Mapper Init()
        {
            if(_mapper == null)
            {
                _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperServiceProfile())));
            }
            return _mapper;
        }
        private  AutoMapperServiceProfile()
        {
            CreateMap<DAL.User, Models.User>().ReverseMap();
            CreateMap<DAL.UserRole, Models.UserRole>().ReverseMap();
            CreateMap<DAL.Appointment, Models.Appointment>().ReverseMap();
            CreateMap<DAL.Department, Models.Department>().ReverseMap();
            CreateMap<DAL.Faculty, Models.Faculty>().ReverseMap();
            CreateMap<DAL.Schedule, Models.Schedule>().ReverseMap();
            CreateMap<DAL.Student, Models.Student>().ReverseMap();
        }
    }
}
