using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? DayId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}