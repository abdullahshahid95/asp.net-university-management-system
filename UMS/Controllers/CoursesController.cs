using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;
using System.Data.Entity;

namespace UMS.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Courses
        public ActionResult Index()
        {
            var courses = _context.Course.OrderBy(o => o.SemesterId);
            var courseWithSemester = courses.Include(s => s.Semester).Include(d => d.Department);


            return View(courseWithSemester);
        }
        
        public ActionResult New()
        {
            ViewBag.departments = _context.Departments;
            ViewBag.semesters = _context.Semester;
            return View("CourseForm");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.flag = 1;
            ViewBag.departments = _context.Departments;
            ViewBag.semesters = _context.Semester;
            var courseIndDb = _context.Course.SingleOrDefault(c => c.Id == id);

            return View("CourseForm", courseIndDb);
        }
        public ActionResult Save(Course course)
        {
            if(course.Id == 0)
            {
                //var deptName = _context.Departments.SingleOrDefault(d => d.Id == course.DepartmentId).ShortName;
                //course.Code = deptName + " - " + course.Code;
                _context.Course.Add(course);
                _context.SaveChanges();
                if(course.LabHours > 0 && !course.Name.Contains("_Lab"))
                {
                    var lab = new Course
                    {
                        Name = course.Name + "_Lab"+course.Id.ToString(),
                        Code = course.Code,
                        LabHours = course.LabHours,
                        TheoryHours = 0,
                        DepartmentId = course.DepartmentId,
                        SemesterId = course.SemesterId

                    };
                    //var lab = new Lab
                    //{
                    //    CourseId = course.Id
                    //};

                    _context.Course.Add(lab);
                    _context.SaveChanges();
                }
            }
            else
            {
                var courseInDb= _context.Course.SingleOrDefault(c => c.Id == course.Id);

                courseInDb.Name = course.Name;
                courseInDb.LabHours = course.LabHours;
                courseInDb.TheoryHours = course.TheoryHours;

                if (course.LabHours < 1)
                {
                    try
                    {
                        var courseName = course.Name + "_Lab" + course.Id.ToString();
                        var labInDB = _context.Course.SingleOrDefault(c => c.Name == courseName);
                        _context.Course.Remove(labInDB);
                    }
                    catch(Exception)
                    {

                    }
                }
                else
                {
                    var courseName = course.Name + "_Lab" + course.Id.ToString();
                    var labInDB = _context.Course.SingleOrDefault(c => c.Name == courseName);

                    if (labInDB == null)
                    {
                        var lab = new Course
                        {
                            Name = courseName,
                            Code = course.Code,
                            LabHours = course.LabHours,
                            TheoryHours = 0,
                            DepartmentId = course.DepartmentId,
                            SemesterId = course.SemesterId

                        };

                        _context.Course.Add(lab);
                    }
                    else
                    {
                        labInDB.Name = courseName;
                        labInDB.LabHours = course.LabHours;
                        labInDB.TheoryHours = 0;
                    }
                }
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Courses");
        }

        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Course.SingleOrDefault(c => c.Id == id);
            _context.Course.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}