using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class TeacherCourseDto
    {
        public string Teacher { get; set; }
        public string Course { get; set; }
        public string Day { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}