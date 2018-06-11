namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQualificationToStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HSCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SSCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "SSCTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "SSCObtained", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "SSCSeat", c => c.String(nullable: false));
            AddColumn("dbo.Students", "HSCTotal", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "HSCObtained", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "HSCSeat", c => c.String(nullable: false));
            AddColumn("dbo.Students", "SSCId", c => c.Int());
            AddColumn("dbo.Students", "HSCId", c => c.Int());
            AlterColumn("dbo.Students", "Picture", c => c.String(nullable: false));
            CreateIndex("dbo.Students", "SSCId");
            CreateIndex("dbo.Students", "HSCId");
            AddForeignKey("dbo.Students", "HSCId", "dbo.HSCs", "Id");
            AddForeignKey("dbo.Students", "SSCId", "dbo.SSCs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SSCId", "dbo.SSCs");
            DropForeignKey("dbo.Students", "HSCId", "dbo.HSCs");
            DropIndex("dbo.Students", new[] { "HSCId" });
            DropIndex("dbo.Students", new[] { "SSCId" });
            AlterColumn("dbo.Students", "Picture", c => c.String());
            DropColumn("dbo.Students", "HSCId");
            DropColumn("dbo.Students", "SSCId");
            DropColumn("dbo.Students", "HSCSeat");
            DropColumn("dbo.Students", "HSCObtained");
            DropColumn("dbo.Students", "HSCTotal");
            DropColumn("dbo.Students", "SSCSeat");
            DropColumn("dbo.Students", "SSCObtained");
            DropColumn("dbo.Students", "SSCTotal");
            DropTable("dbo.SSCs");
            DropTable("dbo.HSCs");
        }
    }
}
