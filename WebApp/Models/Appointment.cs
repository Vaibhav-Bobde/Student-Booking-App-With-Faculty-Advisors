using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int FacultyId { get; set; }
        public int StudentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AppointmentHappened { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Student Student { get; set; }
    }
}
