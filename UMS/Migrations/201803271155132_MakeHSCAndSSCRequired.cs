namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeHSCAndSSCRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "HSCId", "dbo.HSCs");
            DropForeignKey("dbo.Students", "SSCId", "dbo.SSCs");
            DropIndex("dbo.Students", new[] { "SSCId" });
            DropIndex("dbo.Students", new[] { "HSCId" });
            AlterColumn("dbo.Students", "SSCId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "HSCId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SSCId");
            CreateIndex("dbo.Students", "HSCId");
            AddForeignKey("dbo.Students", "HSCId", "dbo.HSCs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "SSCId", "dbo.SSCs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SSCId", "dbo.SSCs");
            DropForeignKey("dbo.Students", "HSCId", "dbo.HSCs");
            DropIndex("dbo.Students", new[] { "HSCId" });
            DropIndex("dbo.Students", new[] { "SSCId" });
            AlterColumn("dbo.Students", "HSCId", c => c.Int());
            AlterColumn("dbo.Students", "SSCId", c => c.Int());
            CreateIndex("dbo.Students", "HSCId");
            CreateIndex("dbo.Students", "SSCId");
            AddForeignKey("dbo.Students", "SSCId", "dbo.SSCs", "Id");
            AddForeignKey("dbo.Students", "HSCId", "dbo.HSCs", "Id");
        }
    }
}
