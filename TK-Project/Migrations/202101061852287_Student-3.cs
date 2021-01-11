namespace TK_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrator",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ApprovedBy_Id = c.String(maxLength: 128),
                        Departement = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Citizenship = c.String(),
                        DOB = c.DateTimeOffset(nullable: false, precision: 7),
                        NIK = c.String(),
                        Religion = c.Int(nullable: false),
                        Approved = c.DateTimeOffset(nullable: false, precision: 7),
                        Registered = c.DateTimeOffset(nullable: false, precision: 7),
                        Updated = c.DateTimeOffset(nullable: false, precision: 7),
                        RegistrationStatus = c.Int(nullable: false),
                        KKNumber = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        RTRW = c.String(),
                        SubDistrict = c.String(),
                        Districts = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApprovedBy_Id)
                .Index(t => t.Id)
                .Index(t => t.ApprovedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Administrator", "ApprovedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Administrator", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Administrator", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.Administrator", new[] { "Id" });
            DropTable("dbo.Administrator");
        }
    }
}
