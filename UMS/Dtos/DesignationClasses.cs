using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DesignationDto
    {
        public List<Designation> designationList;
        public List<Designation> empDesignationList;
        public DesignationDto()
        {
            empDesignationList = new List<Designation>();
            empDesignationList.Add(new Designation { Id = 1, Name = "Department Admin" });
            empDesignationList.Add(new Designation { Id = 2, Name = "Application Admin" });

            designationList = new List<Designation>();
            designationList.Add(new Designation { Id = 1, Name = "Junior Lecturer" });
            designationList.Add(new Designation { Id = 2, Name = "Lecturer" });
            designationList.Add(new Designation { Id = 3, Name = "Assistant Professor" });
            designationList.Add(new Designation { Id = 4, Name = "Professor" });
        }
    }
}