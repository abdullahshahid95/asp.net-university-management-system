using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using UMS.Models;

namespace UMS.Controllers
{
    public class DepartmentsController : Controller
    {
        ApplicationDbContext _context;
        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Departments
        public ActionResult Index()
        {
            var departments = _context.Departments;

            return View(departments);
        }
        public ActionResult New()
        {
            return View("DepartmentForm");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.flag = 1;
            var departmentInDb = _context.Departments.SingleOrDefault(d => d.Id == id);
            return View("DepartmentForm", departmentInDb);
        }
        public ActionResult Save(Department department)
        {
            if (department.Id == 0)
            {
                _context.Departments.Add(department);
            }
            else
            {
                var departmentInDb = _context.Departments.SingleOrDefault(d => d.Id == department.Id);
                departmentInDb.Name = department.Name;
                departmentInDb.ShortName = department.ShortName;
                departmentInDb.Building = department.Building;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Departments");
        }

        public ActionResult Details(int id)
        {
            var students = _context.Students.Where(s => s.DepartmentId == id);
            int count = students.Count();

            var department = _context.Departments.SingleOrDefault(d => d.Id == id);

            if (department == null)
                return HttpNotFound();

            ViewBag.department = department;
            ViewBag.studentCount = count;

            return View();
        }

        public ActionResult Delete(int id)
        {
            var department = _context.Departments.SingleOrDefault(d => d.Id == id);

            if (department == null)
                return HttpNotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index", "Departments");
        }
    }
}