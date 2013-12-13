namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Willthishelp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects");
            DropIndex("dbo.Topics", new[] { "VolunteerProject_Id" });
            CreateIndex("dbo.Topics", "VolunteerProject_Id");
            AddForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects");
            DropIndex("dbo.Topics", new[] { "VolunteerProject_Id" });
            CreateIndex("dbo.Topics", "VolunteerProject_Id");
            AddForeignKey("dbo.Topics", "VolunteerProject_Id", "dbo.VolunteerProjects", "Id");
        }
    }
}
