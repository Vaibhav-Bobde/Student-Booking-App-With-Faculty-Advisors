using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ServiceLayer.Models;
using AutoMapper;
namespace ServiceLayer.Services
{
    public class UserService: BaseService, IUserService
    {
        public User GetUser(string emailId, string pwd)
        {
            DAL.User dbUser = base.facAppDataRepo.GetUser(emailId, pwd);
            return _mapper.Map<DAL.User, Models.User>(dbUser);
        }
        public bool CreateUser(User user)
        {
            int deptId = user.DeptId.Value;
            int roleId = user.RoleId.Value ;
            facAppDataRepo.AddUser(_mapper.Map<DAL.User>(user));
            facAppDataRepo.SaveChangesToDB();
            DAL.User usr = facAppDataRepo.GetUser(user.EmailId, user.Pwd);
            if(user.RoleId == 2)
            {
                facAppDataRepo.AddFaculty(new DAL.Faculty() { DeptId = deptId, IsScheduleEditEnabled = false, Uid = usr.Uid });
            }
            else if(user.RoleId == 3)
            {
                facAppDataRepo.AddStudent(new DAL.Student() { DeptId = deptId, Uid = usr.Uid });
            }
            bool status = facAppDataRepo.SaveChangesToDB();
            return status;
        }
    }
}
