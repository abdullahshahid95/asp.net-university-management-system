using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMS.Models;

namespace UMS.ViewModels
{
    public class StudentFormViewModel
    {
        public int Flag { get; set; }
        public IEnumerable<Program> Programs { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<SSC> SSC { get; set; }
        public IEnumerable<HSC> HSC { get; set; }
        public IEnumerable<Day> Day { get; set; }
        public IEnumerable<Month> Month { get; set; }
        public IEnumerable<Year> Year { get; set; }
        public Student Student { get; set; }
    }
}