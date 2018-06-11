namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSemesterRequiredInCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            AlterColumn("dbo.Courses", "SemesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "SemesterId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            AlterColumn("dbo.Courses", "SemesterId", c => c.Int());
            CreateIndex("dbo.Courses", "SemesterId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "Id");
        }
    }
}
