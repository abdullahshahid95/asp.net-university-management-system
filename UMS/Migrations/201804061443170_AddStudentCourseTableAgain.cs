namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddStudentCourseTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AcademicsId = c.Int(nullable: false),
                    CourseId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Academics", t => t.AcademicsId, cascadeDelete: true)
                .Index(t => t.AcademicsId)
                .Index(t => t.CourseId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "AcademicsId", "dbo.Academics");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "AcademicsId" });
            DropTable("dbo.StudentCourses");
        }
    }
}
