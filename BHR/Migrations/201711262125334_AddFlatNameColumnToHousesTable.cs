namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlatNameColumnToHousesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "FlatName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Houses", "FlatName");
        }
    }
}