namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentAcademicsId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.StudentAcademics", t => t.StudentAcademicsId, cascadeDelete: true)
                .Index(t => t.StudentAcademicsId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentAcademicsId", "dbo.StudentAcademics");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentAcademicsId" });
            DropTable("dbo.StudentCourses");
        }
    }
}
