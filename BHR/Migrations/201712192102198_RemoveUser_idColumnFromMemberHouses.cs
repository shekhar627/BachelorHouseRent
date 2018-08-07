namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUser_idColumnFromMemberHouses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemberHouses", "User_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberHouses", "User_id", c => c.Int(nullable: false));
        }
    }
}
