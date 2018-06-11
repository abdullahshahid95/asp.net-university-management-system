using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.Models;
using UMS.Dtos;
using System.Data.Entity;

namespace UMS.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employee= _context.Employee;
            return View(employee);
        }

        public ActionResult New()
        {
            DesignationDto d = new DesignationDto();
            ViewBag.designations = d.empDesignationList;
            return View();
        }
        public ActionResult Edit(int id)
        {
            var employeeInDb = _context.Employee.SingleOrDefault(e => e.Id == id);

            DesignationDto d = new DesignationDto();

            ViewBag.designations = d.empDesignationList;
            ViewBag.flag = 1;
            ViewBag.salary = _context.EmployeeSalaries.Where(s => s.EmployeeId == id).Include(m => m.Month).Include(y => y.Year);

            return View("New", employeeInDb);
        }
        public ActionResult Details(int id)
        {
            DesignationDto d = new DesignationDto();
            var employeeInDb = _context.Employee.SingleOrDefault(e => e.Id == id);
            ViewBag.salaries = _context.EmployeeSalaries.Where(s => s.EmployeeId == id).Include(m => m.Month).Include(y => y.Year);
            ViewBag.designation = d.empDesignationList.SingleOrDefault(c => c.Id == employeeInDb.DesignationId);

            return View(employeeInDb);
        }
        public ActionResult Save(Employee employee)
        {
            if(employee.Id == 0)
            {
                Random random = new Random();
                employee.Password = random.Next(100000, 999999).ToString();
                //save picture

                HttpPostedFileBase picture = Request.Files[0];

                string pictureName = employee.Name + "_" + random.Next(1, 9999).ToString() + "." + System.IO.Path.GetExtension(picture.FileName);

                string picturePath = System.IO.Path.Combine(
                                   Server.MapPath("~/Photos"), pictureName);
                picture.SaveAs(picturePath);

                employee.Picture = pictureName;
                _context.Employee.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Teachers.SingleOrDefault(t => t.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.Qualification = employee.Qualification;
                employeeInDb.Gender = employee.Gender;
                //teacherInDb.Picture = teacher.Picture;
                employeeInDb.Address = employee.Address;
                employeeInDb.Mobile = employee.Mobile;
                employeeInDb.DesignationId = employee.DesignationId;

                _context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            _context.SaveChanges();

            var employeeId = employee.Id;
            var username = employee.Name + "-" + employeeId.ToString();
            employee.Username = username;
            _context.SaveChanges();

            return RedirectToAction("New", "EmployeeSalaries", new { id = employeeId });
        }

        public ActionResult Delete(int id)
        {
            var employeeInDb = _context.Employee.SingleOrDefault(e => e.Id == id);
            string picturePath = Server.MapPath("~/Photos/" + employeeInDb.Picture);

            if (System.IO.File.Exists(picturePath))
            {
                System.IO.File.Delete(picturePath);
            }
            _context.Employee.Remove(employeeInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
    }
}