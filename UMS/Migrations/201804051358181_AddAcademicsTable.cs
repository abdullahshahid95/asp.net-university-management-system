namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAcademicsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Academics",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Section = c.String(),
                    StudentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.StudentAcademics", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentAcademics", new[] { "StudentId" });
            DropTable("dbo.StudentAcademics");
        }
    }
}
