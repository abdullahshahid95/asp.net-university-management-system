namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Qualification = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
