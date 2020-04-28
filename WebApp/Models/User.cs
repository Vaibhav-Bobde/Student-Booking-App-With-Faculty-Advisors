using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Serializable]
    public class User
    {
        public int Uid { get; set; }

        [Required(ErrorMessage="Please enter Email Id.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Please enter First Name.")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        public string Lname { get; set; }
        [Required]
        public int? RoleId { get; set; }
        [Required]
        public int? DeptId { get; set; }
    }
}