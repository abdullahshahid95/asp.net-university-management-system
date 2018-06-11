using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class DayClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Day
    {
        public List<DayClass> days = new List<DayClass>();

        public Day()
        {
            days.Add(new DayClass { Id = 1, Name = "Monday" });
            days.Add(new DayClass { Id = 2, Name = "Tuesday" });
            days.Add(new DayClass { Id = 3, Name = "Wednesday" });
            days.Add(new DayClass { Id = 4, Name = "Thursday" });
            days.Add(new DayClass { Id = 5, Name = "Friday" });
            days.Add(new DayClass { Id = 6, Name = "Saturday" });
            days.Add(new DayClass { Id = 7, Name = "Sunday" });
        }
    }
}