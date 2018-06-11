namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayMonthYearToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DayId", c => c.Int());
            AddColumn("dbo.Students", "MonthId", c => c.Int());
            AddColumn("dbo.Students", "YearId", c => c.Int());
            CreateIndex("dbo.Students", "DayId");
            CreateIndex("dbo.Students", "MonthId");
            CreateIndex("dbo.Students", "YearId");
            AddForeignKey("dbo.Students", "DayId", "dbo.Days", "Id");
            AddForeignKey("dbo.Students", "MonthId", "dbo.Months", "Id");
            AddForeignKey("dbo.Students", "YearId", "dbo.Years", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "YearId", "dbo.Years");
            DropForeignKey("dbo.Students", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Students", "DayId", "dbo.Days");
            DropIndex("dbo.Students", new[] { "YearId" });
            DropIndex("dbo.Students", new[] { "MonthId" });
            DropIndex("dbo.Students", new[] { "DayId" });
            DropColumn("dbo.Students", "YearId");
            DropColumn("dbo.Students", "MonthId");
            DropColumn("dbo.Students", "DayId");
        }
    }
}
