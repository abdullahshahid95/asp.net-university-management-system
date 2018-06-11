namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignationIdToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DesignationId", c => c.Int());
            DropColumn("dbo.Teachers", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Designation", c => c.String());
            DropColumn("dbo.Teachers", "DesignationId");
        }
    }
}
