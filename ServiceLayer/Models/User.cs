using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string EmailId { get; set; }
        public string Pwd { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? RoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
