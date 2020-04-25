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
        public string StartTimeStr { get { return StartTime.ToString(@"HH\:mm"); }  }
        public DateTime EndTime { get; set; }
        public string EndTimeStr { get { return EndTime.ToString(@"HH\:mm"); } }
        public bool AppointmentHappened { get; set; }
        public bool IsOnWaitList { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Student Student { get; set; }
    }
}
