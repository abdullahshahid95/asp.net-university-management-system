using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMS.Models;
using UMS.Dtos;
//using System.Web.Mvc;

namespace UMS.Controllers.Api
{
    public class NewTeacherCourseController : ApiController
    {
        ApplicationDbContext _context;
        public NewTeacherCourseController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult SaveTeacherCourse(SaveCourseDto saveCourseDto)
        {
            //
            if(saveCourseDto.flag == 1.5)
            {

                var courseId = saveCourseDto.CourseIds[0];
                var section = saveCourseDto.Sections[0];
                var dayId = saveCourseDto.DayIds[0];
                var room = saveCourseDto.Rooms[0];
                var shour = saveCourseDto.SHours[0];
                var sminute = saveCourseDto.SMinutes[0];
                var sampm = saveCourseDto.SAMPMs[0];
                var ehour = saveCourseDto.EHours[0];
                var eminute = saveCourseDto.EMinutes[0];
                var eampm = saveCourseDto.EAMPMs[0];

                //Making time
                var startTime = shour.ToString() + ":" + sminute.ToString() + sampm;
                var endTime = ehour.ToString() + ":" + eminute.ToString() + eampm;
                //

                var list = _context.TeacherCourse.Where(
                    c => c.TeacherId == saveCourseDto.TeacherId
                    && c.CourseId == courseId
                    && c.Section == section
                    && c.DayId == dayId
                    && c.Room == room
                    && c.StartTime == startTime
                    && c.EndTime == endTime);

                var timing = _context.TeacherCourse.Where(
                    t => t.StartTime == startTime
                    && t.Room == room
                    );

                if (timing.Any())
                {
                    return Ok(room + " is already selected at " + startTime);
                }

                if (list.Any())
                {
                    return Ok(1);
                }

                return Ok(2);
            }
            //
            //
            var shours = saveCourseDto.SHours;
            var sminutes = saveCourseDto.SMinutes;
            var sampms = saveCourseDto.SAMPMs;
            var ehours = saveCourseDto.EHours;
            var eminutes = saveCourseDto.EMinutes;
            var eampms = saveCourseDto.EAMPMs;

            
            //
            var teacherInDb = _context.Teachers.SingleOrDefault(t => t.Id == saveCourseDto.TeacherId);
            var courseIds = saveCourseDto.CourseIds;
            var sections = saveCourseDto.Sections;
            var dayIds = saveCourseDto.DayIds;
            var rooms = saveCourseDto.Rooms;
            //Making time
            var startTimes = new List<string>();
            var endtTimes = new List<string>();
            //var startMinutes = new List<int>();
            //var startAmpms = new List<string>();

            for (int i = 0; i < shours.Count; i++)
            {
                startTimes.Add(shours[i].ToString() + ":" + sminutes[i].ToString() + sampms[i]);
                endtTimes.Add(ehours[i].ToString() + ":" + eminutes[i].ToString() + eampms[i]);
            }

            //var endMinutes = new List<int>();
            //var endtAmpms = new List<string>();
            //

            var courseSections = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < courseIds.Count; i++)
            {
                courseSections.Add(new KeyValuePair<string, int>(sections[i], courseIds[i]));
            }

            for(int i = 0; i<courseIds.Count; i++)
            {
                var teacherCourse = new TeacherCourse
                {
                    TeacherId = teacherInDb.Id,
                    CourseId = courseIds[i],
                    Section = sections[i],
                    DayId = dayIds[i],
                    Room = rooms[i],
                    StartTime = startTimes[i],
                    EndTime = endtTimes[i]
                };

                _context.TeacherCourse.Add(teacherCourse);
            }

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var record = _context.TeacherCourse.SingleOrDefault(t => t.Id == id);
            _context.TeacherCourse.Remove(record);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpGet]
        //public int CheckTeacherCourse(int n)
        //{
        //    if (_context.TeacherCourse.Where(c => c.TeacherId == n).Any())
        //        return 68;
        //    //CheckCourseDto checkCourseDto

        //    //var teacherId = checkCourseDto.TeacherId;
        //    //var courseId = checkCourseDto.CourseId;
        //    //var section = checkCourseDto.Section;

        //    //var recordInDb = _context.TeacherCourse.Where(
        //    //    c => c.TeacherId == teacherId 
        //    //    && c.CourseId==courseId 
        //    //    && c.Section == section);

        //    //if (recordInDb.Any())
        //    //    return 1;

        //    return 69;
        //}
    }
}
