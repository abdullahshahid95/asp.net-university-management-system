namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnivStudentsToNumberOfStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NumberofStudents", "UnivStudents", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NumberofStudents", "UnivStudents");
        }
    }
}
