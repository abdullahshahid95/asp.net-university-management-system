using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Fee
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Unpaid { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Semester Semester { get; set; }
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
    }
}