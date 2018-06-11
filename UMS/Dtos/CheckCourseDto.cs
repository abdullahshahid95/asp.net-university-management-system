using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class CheckCourseDto
    {
        public int TeacherId { get; set; }
        public string Section { get; set; }
        public int CourseId { get; set; }
    }
}