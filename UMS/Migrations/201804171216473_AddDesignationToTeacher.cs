namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignationToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Designation");
        }
    }
}
