using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
namespace ServiceLayer.Interface
{
    public interface IUserService
    {
        User GetUser(string emailId, string pwd);
    }
}
