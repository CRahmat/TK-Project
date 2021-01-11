namespace TK_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "MaritalStatus");
            DropColumn("dbo.AspNetUsers", "Institution");
            DropColumn("dbo.AspNetUsers", "Title");
            DropColumn("dbo.AspNetUsers", "Descriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Descriptions", c => c.String());
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            AddColumn("dbo.AspNetUsers", "Institution", c => c.String());
            AddColumn("dbo.Students", "MaritalStatus", c => c.Boolean(nullable: false));
        }
    }
}
