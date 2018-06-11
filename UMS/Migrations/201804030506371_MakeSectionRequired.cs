namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSectionRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Section", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Section", c => c.String());
        }
    }
}
