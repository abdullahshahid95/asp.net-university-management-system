namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DateAdded");
        }
    }
}
