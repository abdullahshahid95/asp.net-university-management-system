using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public string Qualification { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public DateTime DateAdded { get; set; }
    }
}