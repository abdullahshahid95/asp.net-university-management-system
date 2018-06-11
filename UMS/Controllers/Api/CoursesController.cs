using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMS.Models;

namespace UMS.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Course> GetCourses(string query = null)
        {
            var coursesQuery = _context.Course.ToList();
            if(!string.IsNullOrWhiteSpace(query))
                coursesQuery = _context.Course.Where(c => c.Name.Contains(query)).ToList();

            return coursesQuery;
        }
    }
}
