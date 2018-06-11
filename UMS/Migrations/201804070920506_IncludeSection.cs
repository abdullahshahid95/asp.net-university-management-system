namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeSection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Academics", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Fees", "AcademicsId", "dbo.Academics");
            DropForeignKey("dbo.StudentCourses", "AcademicsId", "dbo.Academics");
            DropIndex("dbo.Academics", new[] { "StudentId" });
            DropIndex("dbo.Academics", new[] { "SemesterId" });
            DropIndex("dbo.Fees", new[] { "AcademicsId" });
            DropIndex("dbo.StudentCourses", new[] { "AcademicsId" });
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.Fees", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.StudentCourses", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Fees", "StudentId");
            CreateIndex("dbo.StudentCourses", "StudentId");
            AddForeignKey("dbo.Fees", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Fees", "AcademicsId");
            DropColumn("dbo.StudentCourses", "AcademicsId");
            DropTable("dbo.Academics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Academics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Section = c.String(),
                        StudentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentCourses", "AcademicsId", c => c.Int(nullable: false));
            AddColumn("dbo.Fees", "AcademicsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Sections", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Fees", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.Sections", new[] { "StudentId" });
            DropIndex("dbo.Fees", new[] { "StudentId" });
            DropColumn("dbo.StudentCourses", "StudentId");
            DropColumn("dbo.Fees", "StudentId");
            DropTable("dbo.Sections");
            CreateIndex("dbo.StudentCourses", "AcademicsId");
            CreateIndex("dbo.Fees", "AcademicsId");
            CreateIndex("dbo.Academics", "SemesterId");
            CreateIndex("dbo.Academics", "StudentId");
            AddForeignKey("dbo.StudentCourses", "AcademicsId", "dbo.Academics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Fees", "AcademicsId", "dbo.Academics", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Academics", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters", "Id", cascadeDelete: true);
        }
    }
}
