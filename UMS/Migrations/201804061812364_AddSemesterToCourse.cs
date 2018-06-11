namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "SemesterId", c => c.Int());
            CreateIndex("dbo.Courses", "SemesterId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropColumn("dbo.Courses", "SemesterId");
        }
    }
}
