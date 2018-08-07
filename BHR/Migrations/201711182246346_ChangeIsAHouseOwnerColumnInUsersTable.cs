namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIsAHouseOwnerColumnInUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsAHouseOwner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsAHouseOwner", c => c.Boolean());
        }
    }
}
