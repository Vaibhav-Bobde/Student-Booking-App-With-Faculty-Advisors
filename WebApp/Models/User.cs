using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Serializable]
    public class User
    {
        public int Uid { get; set; }
        public string EmailId { get; set; }
        public string Pwd { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? RoleId { get; set; }
    }
}