namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFlatNameColumnFromHousesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Houses", "FlatName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "FlatName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
