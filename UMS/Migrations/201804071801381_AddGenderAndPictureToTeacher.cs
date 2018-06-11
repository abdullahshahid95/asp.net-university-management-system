namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderAndPictureToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.Teachers", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Picture");
            DropColumn("dbo.Teachers", "Gender");
        }
    }
}
