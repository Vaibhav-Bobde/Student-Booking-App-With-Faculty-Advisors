namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY_APP.Faculty")]
    public partial class Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faculty()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int FacultyId { get; set; }

        [StringLength(255)]
        public string Fname { get; set; }

        [StringLength(255)]
        public string Lname { get; set; }

        public int? DeptId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual Department Department { get; set; }
    }
}
