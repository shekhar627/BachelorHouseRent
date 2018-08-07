namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnToMemberHouses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberHouses", "UserId", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberHouses", "UserId");
        }
    }
}
