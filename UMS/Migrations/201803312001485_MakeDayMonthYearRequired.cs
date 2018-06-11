namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDayMonthYearRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "DayId", "dbo.Days");
            DropForeignKey("dbo.Students", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Students", "YearId", "dbo.Years");
            DropIndex("dbo.Students", new[] { "DayId" });
            DropIndex("dbo.Students", new[] { "MonthId" });
            DropIndex("dbo.Students", new[] { "YearId" });
            AlterColumn("dbo.Students", "DayId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "MonthId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "YearId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DayId");
            CreateIndex("dbo.Students", "MonthId");
            CreateIndex("dbo.Students", "YearId");
            AddForeignKey("dbo.Students", "DayId", "dbo.Days", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "MonthId", "dbo.Months", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "YearId", "dbo.Years", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "YearId", "dbo.Years");
            DropForeignKey("dbo.Students", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Students", "DayId", "dbo.Days");
            DropIndex("dbo.Students", new[] { "YearId" });
            DropIndex("dbo.Students", new[] { "MonthId" });
            DropIndex("dbo.Students", new[] { "DayId" });
            AlterColumn("dbo.Students", "YearId", c => c.Int());
            AlterColumn("dbo.Students", "MonthId", c => c.Int());
            AlterColumn("dbo.Students", "DayId", c => c.Int());
            CreateIndex("dbo.Students", "YearId");
            CreateIndex("dbo.Students", "MonthId");
            CreateIndex("dbo.Students", "DayId");
            AddForeignKey("dbo.Students", "YearId", "dbo.Years", "Id");
            AddForeignKey("dbo.Students", "MonthId", "dbo.Months", "Id");
            AddForeignKey("dbo.Students", "DayId", "dbo.Days", "Id");
        }
    }
}
