namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnToUserHousesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserHouses", "UserId", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserHouses", "UserId");
        }
    }
}
