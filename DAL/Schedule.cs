using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("FACULTY_APP.Schedule")]
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FacultyId { get; set; }
        [StringLength(255)]
        public string Day { get; set; }
        public TimeSpan? AvailableFromTime { get; set; }
        public TimeSpan? AvailableTillTime { get; set; }
        public bool IsUnavailableEntireDay { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
