using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Display(Name = "Lab Hours")]
        public int LabHours { get; set; }
        [Display(Name = "Theory Hours")]
        public int TheoryHours { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Semester Semester { get; set; }
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
    }
}