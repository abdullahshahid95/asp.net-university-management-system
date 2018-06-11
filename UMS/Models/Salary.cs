using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Unpaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Year Year { get; set; }
        [Display(Name = "Year")]
        public int YearId { get; set; }
        public Month Month { get; set; }
        [Display(Name = "Month")]
        public int MonthId { get; set; }
    }
}