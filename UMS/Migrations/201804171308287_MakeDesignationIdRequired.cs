namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDesignationIdRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "DesignationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "DesignationId", c => c.Int());
        }
    }
}
