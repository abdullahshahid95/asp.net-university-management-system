namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFatherName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FatherName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FatherName");
        }
    }
}
