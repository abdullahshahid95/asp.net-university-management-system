namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterToAcademics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Academics", "SemesterId", c => c.Int());
            CreateIndex("dbo.Academics", "SemesterId");
            AddForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Academics", new[] { "SemesterId" });
            DropColumn("dbo.Academics", "SemesterId");
        }
    }
}
