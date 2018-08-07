namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUser_IdColumnFromUserHousesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserHouses", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserHouses", "User_Id", c => c.Int(nullable: false));
        }
    }
}
