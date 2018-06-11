namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeSalaries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unpaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        MonthId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Months", t => t.MonthId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.YearId)
                .Index(t => t.MonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSalaries", "YearId", "dbo.Years");
            DropForeignKey("dbo.EmployeeSalaries", "MonthId", "dbo.Months");
            DropForeignKey("dbo.EmployeeSalaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeSalaries", new[] { "MonthId" });
            DropIndex("dbo.EmployeeSalaries", new[] { "YearId" });
            DropIndex("dbo.EmployeeSalaries", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeSalaries");
        }
    }
}
