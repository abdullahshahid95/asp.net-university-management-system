namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLabsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labs", "CourseId", "dbo.Courses");
            DropIndex("dbo.Labs", new[] { "CourseId" });
            DropTable("dbo.Labs");
        }
    }
}
