namespace UMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropStudentCoursesTable : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE StudentCourses");
        }
        
        public override void Down()
        {
        }
    }
}
