using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UMS.Models;
using UMS.Dtos;
using UMS.ViewModels;

namespace UMS.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Studnets
        public ActionResult Index()
        {
            var students = _context.Students.OrderByDescending(o => o.DateAdded).Include(s => s.Department).Include(s => s.Program);
            return View(students);
        }

        public ActionResult New()
        {
            var programs = _context.Programs;
            var departments = _context.Departments;
            var ssc = _context.SSC;
            var hsc = _context.HSC;
            

            var viewModel = new StudentFormViewModel
            {
                Flag = 0,
                Programs = programs,
                Departments = departments,
                SSC = ssc,
                HSC = hsc,
                Day = _context.Day,
                Month = _context.Month,
                Year = _context.Year
            };
            return View("StudentForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            var programs = _context.Programs;
            var departments = _context.Departments;
            var ssc = _context.SSC;
            var hsc = _context.HSC;

            var viewModel = new StudentFormViewModel
            {
                Flag = 1,
                Programs = programs,
                Departments = departments,
                SSC = ssc,
                HSC = hsc,
                Student = student,
                Day = _context.Day,
                Month = _context.Month,
                Year = _context.Year
            };

            ViewBag.fees = _context.Fee.Where(f => f.StudentId == id).ToList();
            return View("StudentForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var student = _context.Students.Include(s => s.Program).Include(s => s.Department).SingleOrDefault(s => s.Id == id);
            ViewBag.fees = _context.Fee.Where(f => f.StudentId == id).Include(s => s.Semester).ToList();
            //ViewBag.courses = _context.StudentCourse.Where(c => c.StudentId == id).ToList();
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);
            var section = _context.Section.SingleOrDefault(s => s.StudentId == id).Name;
            var semesters = _context.Fee.Where(f => f.StudentId == id).ToList();
            var lastCount = semesters.Count-1;
            var lastSemesterId = semesters[lastCount].SemesterId;
            var departmentId = studentInDb.DepartmentId;

            var currentCourses = _context.Course.Where(
                c => c.SemesterId == lastSemesterId 
                && c.DepartmentId == departmentId).ToList();

            var currentTimetable = new List<TeacherCourseDto>();
            foreach (var currentCourse in currentCourses)
            {
                var records = _context.TeacherCourse.Where(
                    t => t.CourseId == currentCourse.Id 
                    && t.Section == section).ToList();
                foreach (var record in records)
                {
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
                    for (int i=0; i<starttime.Length; i++)
                    {
                        if(flag == 1)
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
                    var difference = (differencet.Hours*60) + differencet.Minutes;
                    //

                    var teacherName = _context.Teachers.SingleOrDefault(t => t.Id == record.TeacherId).Name;
                    var courseName = _context.Course.SingleOrDefault(c => c.Id == record.CourseId).Name;
                    Dtos.Day d = new Dtos.Day();
                    var days = d.days;
                    var day = days.SingleOrDefault(da => da.Id == record.DayId);

                    if (difference > 50 && record.DayId != 5)
                    {
                        var f = sdateTime;
                        while (f != edateTime)
                        {
                            var stfull = f;
                            f = f.AddMinutes(50);
                            var etfull = f;
                            
                            currentTimetable.Add(
                                new TeacherCourseDto
                                {
                                    Teacher = teacherName,
                                    Course = courseName,
                                    Day = day.Name,
                                    Room = record.Room,
                                    StartTime = stfull.ToString("h:mtt"),
                                    EndTime = etfull.ToString("h:mtt")
                                });
                        }

                    }
                    else if(difference > 45 && record.DayId == 5)
                    {
                        var f = sdateTime;
                        while (f != edateTime)
                        {
                            var stfull = f;
                            f = f.AddMinutes(45);
                            var etfull = f;

                            currentTimetable.Add(
                                new TeacherCourseDto
                                {
                                    Teacher = teacherName,
                                    Course = courseName,
                                    Day = day.Name,
                                    Room = record.Room,
                                    StartTime = stfull.ToString("h:mtt"),
                                    EndTime = etfull.ToString("h:mtt")
                                });
                        }
                    }

                    else
                    {
                        currentTimetable.Add(
                            new TeacherCourseDto
                            {
                                Teacher = teacherName,
                                Course = courseName,
                                Day = day.Name,
                                Room = record.Room,
                                StartTime = record.StartTime,
                                EndTime = record.EndTime
                            });
                    }

                }
            }

            if (student == null)
                return HttpNotFound();

            foreach(var record in currentTimetable)
            {
                if (record.Course.Contains("_Lab"))
                {
                    int index = record.Course.IndexOf("_Lab");
                    var n = record.Course.Remove(index + 4);
                    record.Course = n;
                }
            }
            ViewBag.timetable = currentTimetable;
            return View(student);
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            //if(!ModelState.IsValid)
            //{
            //    var programs = _context.Programs;
            //    var departments = _context.Departments;
            //    var viewModel = new StudentFormViewModel
            //    {
            //        Flag = 0,
            //        Programs = programs,
            //        Departments = departments,
            //        SSC = _context.SSC,
            //        HSC = _context.HSC,
            //        Student = student,
            //        Day = _context.Day,
            //        Month = _context.Month,
            //        Year = _context.Year
            //    };

            //    return View("StudentForm", viewModel);
            //}


            var year = student.BatchYear;
            string departmentName = "";
            string programdeaprtment = "";
            int studentNumber = 0;

            var program = _context.Programs.SingleOrDefault(p => p.Id == student.ProgramId);
            string programName = program.ShortName;


            if(student.Id == 0)
            {       
                studentNumber = _context.Students.Where(n => (n.DepartmentId == student.DepartmentId)
                && n.BatchYear == student.BatchYear).Count() + 1;

                departmentName = _context.Departments.SingleOrDefault(d => d.Id == student.DepartmentId).ShortName;

                
                

                programdeaprtment = programName + departmentName;

                string rollNumber = year+ "-" + 
                    programdeaprtment + "-"
                    + studentNumber.ToString();

                student.RollNumber = rollNumber;

                //save picture
                
                HttpPostedFileBase picture = Request.Files[0];

                string pictureName = rollNumber + "_" + picture.FileName;

                string picturePath = System.IO.Path.Combine(
                                   Server.MapPath("~/Photos"), pictureName);
                picture.SaveAs(picturePath);

                student.Picture = pictureName;

                //catch (Exception e)
                //{
                //    ModelState.AddModelError("uploadError", e);
                //}
                //

                
                var univStudents = _context.Students.Count() + 1;

                student.EnrolmentNumber = univStudents.ToString() +
                    "/" + departmentName +
                    "/" + year;

                Random random = new Random();
                student.password = random.Next(10000, 99999).ToString();
                var yearInDb = _context.Year.SingleOrDefault(y => y.Id == student.YearId);
                var dob = student.MonthId.ToString() + "/" + student.DayId.ToString() + "/" + yearInDb.Name;
                student.DateOfBirth = DateTime.Parse(dob);
                _context.Students.Add(student);
            }

            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                var yearInDb = _context.Year.SingleOrDefault(y => y.Id == student.YearId);
                var dob = student.MonthId.ToString() + "/" + student.DayId.ToString() + "/" + yearInDb.Name;
                //student info
                studentInDb.Name = student.Name;
                studentInDb.ApplicantCnic = student.ApplicantCnic;
                studentInDb.DateOfBirth = DateTime.Parse(dob); ;
                studentInDb.PlaceOfBirth = student.PlaceOfBirth;
                studentInDb.Nationality = student.Nationality;
                studentInDb.Province = student.Province;
                studentInDb.Mobile = student.Mobile;
                studentInDb.Phone = student.Phone;
                studentInDb.Address = student.Address;
                studentInDb.Email = student.Email;
                studentInDb.Gender = student.Gender;
                studentInDb.Picture = student.Picture;

                studentInDb.ProgramId = student.ProgramId;
                studentInDb.DepartmentId = student.DepartmentId;

                studentInDb.password = student.password;
                //guardian info
                studentInDb.GuardianName = student.GuardianName;
                studentInDb.GuardianCnic = student.GuardianCnic;
                studentInDb.Relation = student.Relation;
                studentInDb.Occupation = student.Occupation;
                studentInDb.MonthlyIncome = student.MonthlyIncome;
                studentInDb.GuardianPhone = student.GuardianPhone;
                studentInDb.GuardianMobile = student.GuardianMobile;
                studentInDb.GuardianEmail = student.GuardianEmail;
                studentInDb.GuardianAddress = student.GuardianAddress;
                _context.SaveChanges();
                return RedirectToAction("Index", "Students");
            }

            

            _context.SaveChanges();

            var studentId = student.Id;

            return RedirectToAction("NewSection", "Students", new { id = studentId});
        }
        public ActionResult NewSection(int id)
        {
            var savedStudent = _context.Students.SingleOrDefault(s => s.Id == id);

            var numberOfSavedStudents = _context.Students.Where(
            s => s.DepartmentId == savedStudent.DepartmentId 
            && s.BatchYear == savedStudent.BatchYear).Count();

            if (numberOfSavedStudents <= 5)
            {
                ViewBag.section = "A";
            }
            else if(numberOfSavedStudents > 5 && numberOfSavedStudents <= 10)
            {
                ViewBag.section = "B";
            }
            else if (numberOfSavedStudents > 10 && numberOfSavedStudents <= 20)
            {
                ViewBag.section = "C";
            }
            ViewBag.studentId = id;
            //ViewBag.courses = _context.Course.ToList();
            
            return View("StudentSectionForm");
        }
        public ActionResult EditSection(int id)
        {
            var SectionInDb = _context.Section.SingleOrDefault(s => s.StudentId == id);
            ViewBag.section = SectionInDb.Name;
            ViewBag.studentId = id;
            ViewBag.sectionId = SectionInDb.Id;
            ViewBag.flag = 1;
            return View("StudentSectionForm");
        }
        public ActionResult SaveSection(Section section)
        {
            if(section.Id == 0)
            {
                _context.Section.Add(section);
                _context.SaveChanges();
            }
            else
            {
                var SectionInDb = _context.Section.SingleOrDefault(s => s.StudentId == section.StudentId);
                SectionInDb.Name = section.Name;
                SectionInDb.StudentId = section.StudentId;
                _context.SaveChanges();
                return RedirectToAction("Index", "Students");
            }
            
            return RedirectToAction("New", "StudentSemester", new { id = section.StudentId});
        }

        //[HttpDelete]
        public ActionResult Delete(int Id)
        {
            
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == Id);

            string picturePath = Server.MapPath("~/Photos/" + studentInDb.Picture);

            if (System.IO.File.Exists(picturePath))
            {
                System.IO.File.Delete(picturePath);
            }

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            //return new EmptyResult();

            return RedirectToAction("Index", "Students");
        }

    }
}