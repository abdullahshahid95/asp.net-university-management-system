using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<NumberofStudents> NumberofStudents { get; set; }
        public DbSet<SSC> SSC { get; set; }
        public DbSet<HSC> HSC { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourse { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}