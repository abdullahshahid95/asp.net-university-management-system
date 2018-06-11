using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace UMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }
        public string Building { get; set; }
    }
}