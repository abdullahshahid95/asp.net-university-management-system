namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalaries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unpaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        MonthId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Months", t => t.MonthId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.YearId)
                .Index(t => t.MonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "YearId", "dbo.Years");
            DropForeignKey("dbo.Salaries", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Salaries", "MonthId", "dbo.Months");
            DropIndex("dbo.Salaries", new[] { "MonthId" });
            DropIndex("dbo.Salaries", new[] { "YearId" });
            DropIndex("dbo.Salaries", new[] { "TeacherId" });
            DropTable("dbo.Salaries");
        }
    }
}
