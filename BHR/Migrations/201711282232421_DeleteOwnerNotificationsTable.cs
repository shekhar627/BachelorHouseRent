namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOwnerNotificationsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OwnerNotifications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OwnerNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Owner_id = c.Int(nullable: false),
                        TurnPoint = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
