namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeMobileNumberString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Mobile", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Mobile");
        }
    }
}
