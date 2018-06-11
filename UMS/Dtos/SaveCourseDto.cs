using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMS.Models;

namespace UMS.Dtos
{
    public class SaveCourseDto
    {
        public int TeacherId { get; set; }
        public List<int> CourseIds { get; set; }
        public List<string> Sections { get; set; }
        public List<int> DayIds { get; set; }
        public List<string> Rooms { get; set; }
        public List<int> SHours { get; set; }
        public List<int> SMinutes { get; set; }
        public List<string> SAMPMs { get; set; }
        public List<int> EHours { get; set; }
        public List<int> EMinutes { get; set; }
        public List<string> EAMPMs { get; set; }
        public float? flag { get; set; }
    }
}