namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Section = c.String(),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherCourses", new[] { "CourseId" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherId" });
            DropTable("dbo.TeacherCourses");
        }
    }
}
