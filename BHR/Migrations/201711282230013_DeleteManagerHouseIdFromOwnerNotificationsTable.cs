namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteManagerHouseIdFromOwnerNotificationsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OwnerNotifications", "ManagerHouseId", "dbo.ManagerHouses");
            DropIndex("dbo.OwnerNotifications", new[] { "ManagerHouseId" });
            DropColumn("dbo.OwnerNotifications", "ManagerHouseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OwnerNotifications", "ManagerHouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.OwnerNotifications", "ManagerHouseId");
            AddForeignKey("dbo.OwnerNotifications", "ManagerHouseId", "dbo.ManagerHouses", "Id", cascadeDelete: true);
        }
    }
}
