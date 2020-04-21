namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY_APP.Appointment")]
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? FacultyId { get; set; }
        public int? StudentId { get; set; }

        public DateTime? Date { get; set; }

        public bool? Appointment_Status { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual Student Student { get; set; }
    }
}
