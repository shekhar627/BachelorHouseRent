namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyColumnToManagerHousesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManagerHouses", "Key", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManagerHouses", "Key");
        }
    }
}
