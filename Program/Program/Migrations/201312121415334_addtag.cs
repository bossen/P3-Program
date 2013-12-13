namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tags", newName: "TopicList");
            DropForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers");
            DropForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects");
            DropIndex("dbo.Topics", new[] { "Volunteer_ID" });
            DropIndex("dbo.Topics", new[] { "VolunteerProject_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Topics", "VolunteerProject_Id");
            CreateIndex("dbo.Topics", "Volunteer_ID");
            AddForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects", "Id");
            AddForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers", "ID");
            RenameTable(name: "dbo.Topics", newName: "Tags");
        }
    }
}
