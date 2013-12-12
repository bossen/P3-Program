namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TooManyMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers");
            DropIndex("dbo.Topics", new[] { "Volunteer_ID" });
            CreateIndex("dbo.Topics", "Volunteer_ID");
            AddForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers");
            DropIndex("dbo.Topics", new[] { "Volunteer_ID" });
            CreateIndex("dbo.Topics", "Volunteer_ID");
            AddForeignKey("dbo.Topics", "Volunteer_ID", "dbo.Volunteers", "ID");
        }
    }
}
