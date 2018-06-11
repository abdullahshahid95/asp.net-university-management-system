namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentsAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ApplicantCnic", c => c.String(nullable: false));
            AddColumn("dbo.Students", "PlaceOfBirth", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Nationality", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Province", c => c.String());
            AddColumn("dbo.Students", "Picture", c => c.String());
            AddColumn("dbo.Students", "GuardianCnic", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Relation", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Occupation", c => c.String(nullable: false));
            AddColumn("dbo.Students", "MonthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Students", "GuardianPhone", c => c.String());
            AddColumn("dbo.Students", "GuardianMobile", c => c.String(nullable: false));
            AddColumn("dbo.Students", "GuardianEmail", c => c.String(nullable: false));
            AddColumn("dbo.Students", "GuardianAddress", c => c.String(nullable: false));
            AddColumn("dbo.Departments", "ShortName", c => c.String());
            DropColumn("dbo.Students", "Cnic");
            DropColumn("dbo.Students", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "City", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Cnic", c => c.String(nullable: false));
            DropColumn("dbo.Departments", "ShortName");
            DropColumn("dbo.Students", "GuardianAddress");
            DropColumn("dbo.Students", "GuardianEmail");
            DropColumn("dbo.Students", "GuardianMobile");
            DropColumn("dbo.Students", "GuardianPhone");
            DropColumn("dbo.Students", "MonthlyIncome");
            DropColumn("dbo.Students", "Occupation");
            DropColumn("dbo.Students", "Relation");
            DropColumn("dbo.Students", "GuardianCnic");
            DropColumn("dbo.Students", "Picture");
            DropColumn("dbo.Students", "Province");
            DropColumn("dbo.Students", "Nationality");
            DropColumn("dbo.Students", "PlaceOfBirth");
            DropColumn("dbo.Students", "ApplicantCnic");
        }
    }
}
