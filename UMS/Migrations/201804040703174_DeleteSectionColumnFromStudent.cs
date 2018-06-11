namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSectionColumnFromStudent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Section");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Section", c => c.String(nullable: false));
        }
    }
}
