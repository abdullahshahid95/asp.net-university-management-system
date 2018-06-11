using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        public string Address { get; set; }
        public string password { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Picture { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}