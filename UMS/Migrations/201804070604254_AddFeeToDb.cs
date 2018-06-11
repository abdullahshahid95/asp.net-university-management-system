namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeeToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unpaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AcademicsId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Academics", t => t.AcademicsId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: false)
                .Index(t => t.AcademicsId)
                .Index(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Fees", "AcademicsId", "dbo.Academics");
            DropIndex("dbo.Fees", new[] { "SemesterId" });
            DropIndex("dbo.Fees", new[] { "AcademicsId" });
            DropTable("dbo.Fees");
        }
    }
}
