namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialVolunteerOnly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Name = c.String(),
                        Creation = c.DateTime(nullable: false),
                        Email = c.String(),
                        Association_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Association_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Association_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        Email = c.String(),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VolunteerProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Time = c.DateTime(nullable: false),
                        Description = c.String(),
                        Signup = c.Boolean(nullable: false),
                        Location_Id = c.Int(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.Organizations", t => t.Owner_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Name = c.String(),
                        Creation = c.DateTime(nullable: false),
                        Email = c.String(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accepted = c.Boolean(),
                        Expire = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Project_Id = c.Int(),
                        Volunteer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VolunteerProjects", t => t.Project_Id)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_ID)
                .Index(t => t.Project_Id)
                .Index(t => t.Volunteer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Volunteer_ID", "dbo.Volunteers");
            DropForeignKey("dbo.Volunteers", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.VolunteerProjects", "Owner_Id", "dbo.Organizations");
            DropForeignKey("dbo.Matches", "Project_Id", "dbo.VolunteerProjects");
            DropForeignKey("dbo.VolunteerProjects", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Admins", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Admins", "Association_Id", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Matches", new[] { "Volunteer_ID" });
            DropIndex("dbo.Volunteers", new[] { "Location_Id" });
            DropIndex("dbo.VolunteerProjects", new[] { "Owner_Id" });
            DropIndex("dbo.Matches", new[] { "Project_Id" });
            DropIndex("dbo.VolunteerProjects", new[] { "Location_Id" });
            DropIndex("dbo.Admins", new[] { "Location_Id" });
            DropIndex("dbo.Admins", new[] { "Association_Id" });
            DropIndex("dbo.Organizations", new[] { "Location_Id" });
            DropTable("dbo.Matches");
            DropTable("dbo.Volunteers");
            DropTable("dbo.VolunteerProjects");
            DropTable("dbo.Locations");
            DropTable("dbo.Organizations");
            DropTable("dbo.Admins");
        }
    }
}
