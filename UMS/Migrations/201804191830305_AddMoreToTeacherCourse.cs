namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreToTeacherCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherCourses", "Room", c => c.String());
            AddColumn("dbo.TeacherCourses", "StartTime", c => c.String());
            AddColumn("dbo.TeacherCourses", "EndTime", c => c.String());
            AddColumn("dbo.TeacherCourses", "DayId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeacherCourses", "DayId");
            DropColumn("dbo.TeacherCourses", "EndTime");
            DropColumn("dbo.TeacherCourses", "StartTime");
            DropColumn("dbo.TeacherCourses", "Room");
        }
    }
}
