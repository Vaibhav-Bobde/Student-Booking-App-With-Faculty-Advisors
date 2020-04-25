using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    [Serializable]
    public class Faculty
    {
        public int FacultyId { get; set; }
        public int? Uid { get; set; }
        public int? DeptId { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
