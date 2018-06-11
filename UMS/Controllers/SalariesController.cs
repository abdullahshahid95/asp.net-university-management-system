using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;

namespace UMS.Controllers
{
    public class SalariesController : Controller
    {
        ApplicationDbContext _context;
        public SalariesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();   
        }
        // GET: Salaries

        public ActionResult New(int id)
        {
            var salaryInDb = _context.Salaries.Where(s => s.TeacherId == id).ToList();
            if(salaryInDb.Count() > 0)
            {
                var listCount = salaryInDb.Count();
                var lastSalaryInDb = salaryInDb[listCount - 1];
                ViewBag.lastSalary = lastSalaryInDb.Total;
            }

            ViewBag.teacherId = id;
            ViewBag.months = _context.Month;
            ViewBag.years = _context.Year;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var salaryInDb = _context.Salaries.SingleOrDefault(s => s.Id == id);
            ViewBag.teacherId = salaryInDb.TeacherId;
            ViewBag.months = _context.Month;
            ViewBag.years = _context.Year;
            ViewBag.salaryId = id;
            return View("New", salaryInDb);
        }

        public ActionResult Save(Salary salary)
        {
            if(salary.Id == 0)
            {
                salary.Unpaid = salary.Total - salary.Paid;
                _context.Salaries.Add(salary);
            }
            else
            {
                var salaryInDb = _context.Salaries.SingleOrDefault(s => s.Id == salary.Id);

                salaryInDb.MonthId = salary.MonthId;
                salaryInDb.YearId = salary.YearId;
                salaryInDb.Total = salary.Total;
                salaryInDb.Paid = salary.Paid;
                salaryInDb.Unpaid = salary.Total - salary.Paid;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Teachers");
        }

        
    }
}