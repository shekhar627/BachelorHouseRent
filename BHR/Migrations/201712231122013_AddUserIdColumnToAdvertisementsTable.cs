namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnToAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertisements", "UserId");
            AddForeignKey("dbo.Advertisements", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "UserId", "dbo.Users");
            DropIndex("dbo.Advertisements", new[] { "UserId" });
            DropColumn("dbo.Advertisements", "UserId");
        }
    }
}
