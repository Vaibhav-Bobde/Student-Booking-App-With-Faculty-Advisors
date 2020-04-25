using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string CWID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? DeptId { get; set; }
        public int Uid { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
    }
}
