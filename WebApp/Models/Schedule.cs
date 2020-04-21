using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Day { get; set; }
        public TimeSpan? AvailableFromTime { get; set; }
        public TimeSpan? AvailableTillTime { get; set; }
        public bool IsUnavailableEntireDay { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
