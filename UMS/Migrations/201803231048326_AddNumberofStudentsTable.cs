namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberofStudentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NumberofStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CsStudents = c.Int(nullable: false),
                        CeStudents = c.Int(nullable: false),
                        SeStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NumberofStudents");
        }
    }
}
