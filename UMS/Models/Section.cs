using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }

    }
}