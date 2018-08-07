namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTurnPointColumnToOwnerNotificationsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerNotifications", "TurnPoint", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OwnerNotifications", "TurnPoint");
        }
    }
}
