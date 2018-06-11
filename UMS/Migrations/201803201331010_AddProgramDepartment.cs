namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GuardianName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Cnic = c.String(nullable: false),
                        City = c.String(nullable: false),
                        password = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        BatchYear = c.String(),
                        RollNumber = c.String(),
                        EnrolmentNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Building = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "ProgramId" });
            DropTable("dbo.Programs");
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
        }
    }
}
