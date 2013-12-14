namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatetimeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Creation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Creation", c => c.DateTime(nullable: false));
        }
    }
}
