using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;
using System.Data.Entity;
using UMS.Dtos;

namespace UMS.Controllers
{
    public class TeachersController : Controller
    {
        ApplicationDbContext _context;
        public TeachersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = _context.Teachers.OrderByDescending(o => o.DateAdded);

            return View(teachers);
        }
        public ActionResult New()
        {
            DesignationDto d = new DesignationDto();
            ViewBag.designations = d.designationList;
            return View();
        }
        public ActionResult Edit(int id)
        {
            DesignationDto d = new DesignationDto();
            ViewBag.designations = d.designationList;

            var teacherInDb = _context.Teachers.SingleOrDefault(t => t.Id == id);

            ViewBag.flag = 1;
            ViewBag.salary = _context.Salaries.Where(s => s.TeacherId == id).Include(m => m.Month).Include(y => y.Year);
            return View("New", teacherInDb);
        }
        public ActionResult Details(int id)
        {
            DesignationDto d = new DesignationDto();
            var teacherInDb = _context.Teachers.SingleOrDefault(t => t.Id == id);
            ViewBag.teacherCourses = _context.TeacherCourse.Where(c => c.TeacherId == id).Include(c => c.Course);
            ViewBag.salaries = _context.Salaries.Where(s => s.TeacherId == id).Include(m => m.Month).Include(y => y.Year);
            ViewBag.designation = d.designationList.SingleOrDefault(c => c.Id == teacherInDb.DesignationId);

            var records = _context.TeacherCourse.Where(t => t.TeacherId == id).ToList();
            var timeTable = new List<TeacherTimeTable>();

            foreach (var record in records)
            {
                var teacherName = _context.Teachers.SingleOrDefault(t => t.Id == record.TeacherId).Name;
                var course = _context.Course.SingleOrDefault(c => c.Id == record.CourseId);
                var departmentShortName = _context.Departments.SingleOrDefault(de => de.Id == course.DepartmentId).ShortName;
                var semesterId = _context.Semester.SingleOrDefault(s => s.Id == course.SemesterId).Id;
                Dtos.Day dayClass = new Dtos.Day();
                var days = dayClass.days;
                var day = days.SingleOrDefault(da => da.Id == record.DayId);

                //
                var starttime = record.StartTime;
                var ampm = starttime.Contains("AM") ? "A" : "P";
                var sampm = starttime.Contains("A") ?
                    starttime.Substring(starttime.IndexOf("A")) :
                    starttime.Substring(starttime.IndexOf("P"));

                var endtime = record.EndTime;
                var eampm = endtime.Contains("A") ?
                    endtime.Substring(endtime.IndexOf("A")) :
                    endtime.Substring(endtime.IndexOf("P"));

                var starthour = starttime.Substring(0, starttime.IndexOf(":"));
                var endhour = endtime.Substring(0, endtime.IndexOf(":"));
                var startminute = "";
                var endminute = "";
                var flag = 0;
                for (int i = 0; i < starttime.Length; i++)
                {
                    if (flag == 1)
                    {
                        if (starttime[i] == 'A' || starttime[i] == 'P')
                            break;
                        startminute += starttime[i];
                    }
                    if (starttime[i] == ':')
                    {
                        flag = 1;
                    }
                }
                var flag1 = 0;
                for (int i = 0; i < endtime.Length; i++)
                {
                    if (flag1 == 1)
                    {
                        if (endtime[i] == 'A' || endtime[i] == 'P')
                            break;
                        endminute += endtime[i];
                    }
                    if (endtime[i] == ':')
                    {
                        flag1 = 1;
                    }
                }

                //8/2/1995 12:00:00 AM
                var startD = "8/2/2018 " + starthour + ":" + startminute + ":00 " + sampm;
                var endD = "8/2/2018 " + endhour + ":" + endminute + ":00 " + eampm;
                DateTime sdateTime = DateTime.Parse(startD);
                DateTime edateTime = DateTime.Parse(endD);

                //DateTime d1 = DateTime.Parse(sdateTime.ToString("HH:mm:ss tt"));
                //DateTime d2 = DateTime.Parse(edateTime.ToString("HH:mm:ss tt"));

                TimeSpan differencet = edateTime - sdateTime;
                var difference = (differencet.Hours * 60) + differencet.Minutes;

                if (difference > 50 && record.DayId != 5)
                {
                    var f = sdateTime;
                    while (f != edateTime)
                    {
                        var stfull = f;
                        f = f.AddMinutes(50);
                        var etfull = f;

                        timeTable.Add(
                            new TeacherTimeTable
                            {
                                Teacher = teacherName,
                                Section = record.Section,
                                Semester = semesterId.ToString(),
                                Department = departmentShortName,
                                Course = course.Name,
                                Day = day.Name,
                                Room = record.Room,
                                StartTime = stfull.ToString("h:mtt"),
                                EndTime = etfull.ToString("h:mtt")
                            });
                    }

                }
                else if (difference > 45 && record.DayId == 5)
                {
                    var f = sdateTime;
                    while (f != edateTime)
                    {
                        var stfull = f;
                        f = f.AddMinutes(45);
                        var etfull = f;

                        timeTable.Add(
                            new TeacherTimeTable
                            {
                                Teacher = teacherName,
                                Section = record.Section,
                                Semester = semesterId.ToString(),
                                Department = departmentShortName,
                                Course = course.Name,
                                Day = day.Name,
                                Room = record.Room,
                                StartTime = stfull.ToString("h:mtt"),
                                EndTime = etfull.ToString("h:mtt")
                            });
                    }
                }
                //

                else
                {
                    timeTable.Add(new TeacherTimeTable
                    {
                        Teacher = teacherName,
                        Section = record.Section,
                        Semester = semesterId.ToString(),
                        Department = departmentShortName,
                        Course = course.Name,
                        Day = day.Name,
                        Room = record.Room,
                        StartTime = record.StartTime,
                        EndTime = record.EndTime
                    });
                }
            }

            foreach (var record in timeTable)
            {
                if (record.Course.Contains("_Lab"))
                {
                    int index = record.Course.IndexOf("_Lab");
                    var n = record.Course.Remove(index + 4);
                    record.Course = n;
                }
            }

            ViewBag.timeTable = timeTable;
            return View(teacherInDb);
        }
        public ActionResult Save(Teacher teacher)
        {
            if(teacher.Id == 0)
            {
                Random random = new Random();
                teacher.password = random.Next(10000, 99999).ToString();
                //save picture

                HttpPostedFileBase picture = Request.Files[0];

                string pictureName = teacher.Name + "_" + random.Next(1,9999).ToString() + "." + System.IO.Path.GetExtension(picture.FileName);

                string picturePath = System.IO.Path.Combine(
                                   Server.MapPath("~/Photos"), pictureName);
                picture.SaveAs(picturePath);

                teacher.Picture = pictureName;
                _context.Teachers.Add(teacher);
            }
            else
            {
                var teacherInDb = _context.Teachers.SingleOrDefault(t => t.Id == teacher.Id);
                teacherInDb.Name = teacher.Name;
                teacherInDb.Qualification = teacher.Qualification;
                teacherInDb.Gender = teacher.Gender;
                //teacherInDb.Picture = teacher.Picture;
                teacherInDb.Address = teacher.Address;
                teacherInDb.Mobile = teacher.Mobile;
                teacherInDb.DesignationId = teacher.DesignationId;

                _context.SaveChanges();
                return RedirectToAction("Index", "Teachers");
            }
            _context.SaveChanges();

            var teacherId = teacher.Id;
            var userName = teacher.Name + "-" + teacherId.ToString();
            teacher.UserName = userName;
            _context.SaveChanges();

            return RedirectToAction("New", "Salaries", new {id = teacherId });
        }
        public ActionResult NewCourse()
        {
            ViewBag.courses = _context.Course.OrderBy(o => o.SemesterId).Include(d => d.Department).Include(s => s.Semester);
            ViewBag.labs = _context.Labs.Include(l => l.Course);
            ViewBag.teachers = _context.Teachers;

            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(SaveCourseDto saveCourseDto)
        {
            
            return RedirectToAction("Index", "Students");
        }
        public ActionResult Delete(int id)
        {
            var teacherInDb = _context.Teachers.SingleOrDefault(t => t.Id == id);
            string picturePath = Server.MapPath("~/Photos/" + teacherInDb.Picture);

            if (System.IO.File.Exists(picturePath))
            {
                System.IO.File.Delete(picturePath);
            }
            _context.Teachers.Remove(teacherInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Teachers");
        }

        public ActionResult IndexTeacherCourse()
        {
            var teacherCourse = _context.TeacherCourse.Include(t => t.Teacher).Include(c => c.Course);
            return View(teacherCourse);
        }
        public ActionResult EditTeacherCourse()
        {
            return View();
        }
    }
}