namespace WebApp.Common
{
    public class AutoMapperWebProfile : AutoMapper.Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<ServiceLayer.Models.User, Models.User>().ReverseMap();
            CreateMap<ServiceLayer.Models.UserRole, Models.UserRole>().ReverseMap();
            CreateMap<ServiceLayer.Models.Appointment, Models.Appointment>().ReverseMap();
            CreateMap<ServiceLayer.Models.Department, Models.Department>().ReverseMap();
            CreateMap<ServiceLayer.Models.Faculty, Models.Faculty>().ReverseMap();
            CreateMap<ServiceLayer.Models.Schedule, Models.Schedule>().ReverseMap();
            CreateMap<ServiceLayer.Models.Student, Models.Student>().ReverseMap();
        }
    }
}