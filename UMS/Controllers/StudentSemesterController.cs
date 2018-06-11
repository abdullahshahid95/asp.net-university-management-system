using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;

namespace UMS.Controllers
{
    public class StudentSemesterController : Controller
    {
        ApplicationDbContext _context;
        public StudentSemesterController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Semester
        public ActionResult New(int id)
        {
            ViewBag.semesters = _context.Semester;
            ViewBag.studentId = id;
            return View("New");
        }
        public ActionResult Edit(int id)
        {
            var feeInDb = _context.Fee.SingleOrDefault(f => f.Id == id);
            ViewBag.semesters = _context.Semester;
            ViewBag.semesterId = feeInDb.SemesterId;
            ViewBag.total = feeInDb.Total;
            ViewBag.paid = feeInDb.Paid;
            ViewBag.studentId = feeInDb.StudentId;
            ViewBag.feeId = id;
            return View("New");
        }
        public ActionResult Save(Fee fee)
        {
            if (fee.Id == 0)
            {
                fee.Unpaid = fee.Total - fee.Paid;
                _context.Fee.Add(fee);
                //Finding Student Department
                var student = _context.Students.SingleOrDefault(s => s.Id == fee.StudentId);
                //
                var courses = _context.Course.Where(c =>
                c.SemesterId == fee.SemesterId
                && c.DepartmentId == student.DepartmentId).ToList();

                foreach (var course in courses)
                {
                    var studentCourse = new StudentCourse
                    {
                        CourseId = course.Id,
                        StudentId = fee.StudentId
                    };
                    _context.StudentCourse.Add(studentCourse);
                }
            }
            else
            {
                var feeInDb = _context.Fee.SingleOrDefault(f => f.Id == fee.Id);
                feeInDb.Total = fee.Total;
                feeInDb.Paid = fee.Paid;
                feeInDb.Unpaid = fee.Total - fee.Paid;
                feeInDb.SemesterId = fee.SemesterId;
                feeInDb.StudentId = fee.StudentId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Students");
        }
    }
}