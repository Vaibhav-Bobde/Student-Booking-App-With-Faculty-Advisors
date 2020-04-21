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
    }
}
