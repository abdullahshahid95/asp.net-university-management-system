using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Models
{
    public class Lab
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}