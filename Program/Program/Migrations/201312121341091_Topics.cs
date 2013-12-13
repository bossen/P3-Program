namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Topics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Volunteer_ID = c.Int(),
                        VolunteerProject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TopicID)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_ID)
                .ForeignKey("dbo.VolunteerProjects", t => t.VolunteerProject_Id)
                .Index(t => t.Volunteer_ID)
                .Index(t => t.VolunteerProject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects");
            DropForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers");
            DropIndex("dbo.Topics", new[] { "VolunteerProject_Id" });
            DropIndex("dbo.Topics", new[] { "Volunteer_ID" });
            DropTable("dbo.Topics");
        }
    }
}
