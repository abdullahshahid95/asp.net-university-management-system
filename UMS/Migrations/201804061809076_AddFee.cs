namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Academics", new[] { "SemesterId" });
            AlterColumn("dbo.Academics", "SemesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Academics", "SemesterId");
            AddForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Academics", new[] { "SemesterId" });
            AlterColumn("dbo.Academics", "SemesterId", c => c.Int());
            CreateIndex("dbo.Academics", "SemesterId");
            AddForeignKey("dbo.Academics", "SemesterId", "dbo.Semesters", "Id");
        }
    }
}
