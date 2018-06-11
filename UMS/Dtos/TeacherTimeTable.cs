using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class TeacherTimeTable
    {
        public string Teacher { get; set; }
        public string Section { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string Day { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}