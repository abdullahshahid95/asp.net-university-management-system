namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "DateAdded");
        }
    }
}
