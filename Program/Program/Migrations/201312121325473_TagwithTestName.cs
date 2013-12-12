namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagwithTestName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "TestName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "TestName");
        }
    }
}
