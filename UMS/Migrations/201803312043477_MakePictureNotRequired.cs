namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePictureNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Picture", c => c.String(nullable: false));
        }
    }
}
