using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS.Dtos
{
    public class HourClass
    {
        public int Hour { get; set; }
    }
    public class MinuteClass
    {
        public int Minute { get; set; }
    }
    public class AMPMClass
    {
        public string AmPm { get; set; }
    }

    public class Time
    {
        public List<HourClass> Hours = new List<HourClass>();
        public List<MinuteClass> Minutes = new List<MinuteClass>();
        public List<AMPMClass> AMPM = new List<AMPMClass>();

        public Time()
        {
            for(int i = 1; i <= 12; i++)
            {
                Hours.Add(new HourClass { Hour = i });
            }
            for (int i = 00; i <= 59; i++)
            {
                Minutes.Add(new MinuteClass { Minute = i });
            }
            AMPM.Add(new AMPMClass { AmPm = "AM" });
            AMPM.Add(new AMPMClass { AmPm = "PM" });
        }
    }
}