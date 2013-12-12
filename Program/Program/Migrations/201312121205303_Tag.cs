namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Volunteer_ID = c.Int(),
                        VolunteerProject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_ID)
                .ForeignKey("dbo.VolunteerProjects", t => t.VolunteerProject_Id)
                .Index(t => t.Volunteer_ID)
                .Index(t => t.VolunteerProject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "VolunteerProject_Id", "dbo.VolunteerProjects");
            DropForeignKey("dbo.Tags", "Volunteer_ID", "dbo.Volunteers");
            DropIndex("dbo.Tags", new[] { "VolunteerProject_Id" });
            DropIndex("dbo.Tags", new[] { "Volunteer_ID" });
            DropTable("dbo.Tags");
        }
    }
}
