using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? DeptId { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual Department Department { get; set; }
    }
}
