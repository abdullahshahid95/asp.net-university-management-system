namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSectionToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Section", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Section");
        }
    }
}
