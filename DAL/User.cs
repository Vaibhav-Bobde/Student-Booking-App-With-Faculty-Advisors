namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY_APP.Users")]
    public partial class User
    {
        [Key]
        public int Uid { get; set; }

        [StringLength(255)]
        public string EmailId { get; set; }

        [StringLength(255)]
        public string Pwd { get; set; }
        [StringLength(255)]
        public string Fname { get; set; }
        [StringLength(255)]
        public string Lname { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
