using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Student
    {
        //Student information
        public int Id { get; set; }
        [Required]
        [Display(Name = "Applicant's Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Applicant's CNIC")]
        public string ApplicantCnic { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string Province { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Provide a valid mobile number")]
        [MaxLength(11, ErrorMessage = "Provide a valid mobile number")]
        [MinLength(11, ErrorMessage = "Provide a valid mobile number")]
        public string Mobile { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        public DateTime DateAdded { get; set; }
        //Student Qualification

        //SSC
        [Required]
        [Display(Name = "Total Marks")]
        public float SSCTotal { get; set; }
        [Required]
        [Display(Name = "Obtained Marks")]
        public float SSCObtained { get; set; }
        [Required]
        [Display(Name = "Seat Number")]
        public string SSCSeat { get; set; }
        //[Required]
        //public float SSCEQPercentage { get; set; }
        //[Required]
        //public string SSCEQYear { get; set; }

        //HSC
        [Required]
        [Display(Name = "Total Marks")]
        public float HSCTotal { get; set; }
        [Required]
        [Display(Name = "Obtained Marks")]
        public float HSCObtained { get; set; }
        [Required]
        [Display(Name = "Seat Number")]
        public string HSCSeat { get; set; }
        //[Required]
        //public float HSCEQPercentage { get; set; }
        //[Required]
        //public string HSCEQYear { get; set; }
        //public string DAE { get; set; }

        //Guardian information
        [Required]
        [Display(Name = "Guardian's Name")]
        public string GuardianName { get; set; }
        [Required]
        [Display(Name = "Guardian's CNIC")]
        public string GuardianCnic { get; set; }
        [Required]
        [Display(Name = "Relation with Guardian")]
        public string Relation { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        [Display(Name = "Monthly Income")]
        public decimal MonthlyIncome { get; set; }
        [Display (Name = "Phone Number")]
        public string GuardianPhone { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string GuardianMobile { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string GuardianEmail { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string GuardianAddress { get; set; }


        public string password { get; set; }
        public Program Program { get; set; }
        [Display(Name = "Degree Program")]
        public int ProgramId { get; set; }
        public Department Department { get; set; }
        [Display(Name = "Study Program")]
        public int DepartmentId { get; set; }
        public SSC SSC { get; set; }
        [Required]
        [Display(Name = "SSC Or Equivalent Board")]
        public int SSCId { get; set; }
        public HSC HSC { get; set; }
        [Required]
        [Display(Name = "HSC Or Equivalent Board")]
        public int HSCId { get; set; }
        public Day Day { get; set; }
        public int DayId { get; set; }
        public Month Month { get; set; }
        public int MonthId { get; set; }
        public Year Year { get; set; }
        public int YearId { get; set; }
        public string BatchYear { get; set; }
        public string RollNumber { get; set; }
        public string EnrolmentNumber { get; set; }
    }
}