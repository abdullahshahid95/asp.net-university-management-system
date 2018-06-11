namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "UserName");
        }
    }
}
