using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;

namespace UMS.Controllers
{
    public class EmployeeSalariesController : Controller
    {
        ApplicationDbContext _context;
        public EmployeeSalariesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: EmployeeSalaries

        public ActionResult New(int id)
        {
            var employeeSalaryInDb = _context.EmployeeSalaries.Where(s => s.EmployeeId == id).ToList();
            if (employeeSalaryInDb.Count() > 0)
            {
                var listCount = employeeSalaryInDb.Count();
                var lastEmployeeSalaryInDb = employeeSalaryInDb[listCount - 1];
                ViewBag.lastSalary = lastEmployeeSalaryInDb.Total;
            }

            ViewBag.employeeId = id;
            ViewBag.months = _context.Month;
            ViewBag.years = _context.Year;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var employeeSalaryInDb = _context.EmployeeSalaries.SingleOrDefault(s => s.Id == id);
            ViewBag.employeeId = employeeSalaryInDb.EmployeeId;
            ViewBag.months = _context.Month;
            ViewBag.years = _context.Year;
            ViewBag.employeeSalaryId = id;
            return View("New", employeeSalaryInDb);
        }

        public ActionResult Save(EmployeeSalary employeeSalary)
        {
            if (employeeSalary.Id == 0)
            {
                employeeSalary.Unpaid = employeeSalary.Total - employeeSalary.Paid;
                _context.EmployeeSalaries.Add(employeeSalary);
            }
            else
            {
                var employeeSalaryInDb = _context.EmployeeSalaries.SingleOrDefault(s => s.Id == employeeSalary.Id);

                employeeSalaryInDb.MonthId = employeeSalary.MonthId;
                employeeSalaryInDb.YearId = employeeSalary.YearId;
                employeeSalaryInDb.Total = employeeSalary.Total;
                employeeSalaryInDb.Paid = employeeSalary.Paid;
                employeeSalaryInDb.Unpaid = employeeSalary.Total - employeeSalary.Paid;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
    }
}