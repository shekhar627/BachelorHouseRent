namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerNotificationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        ManagerHouseId = c.Int(nullable: false),
                        Owner_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ManagerHouses", t => t.ManagerHouseId, cascadeDelete: true)
                .Index(t => t.ManagerHouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerNotifications", "ManagerHouseId", "dbo.ManagerHouses");
            DropIndex("dbo.OwnerNotifications", new[] { "ManagerHouseId" });
            DropTable("dbo.OwnerNotifications");
        }
    }
}
