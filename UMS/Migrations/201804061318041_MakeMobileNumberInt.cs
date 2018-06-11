namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeMobileNumberInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Phone", c => c.String());
            DropColumn("dbo.Students", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Phone", c => c.String(nullable: false));
        }
    }
}
