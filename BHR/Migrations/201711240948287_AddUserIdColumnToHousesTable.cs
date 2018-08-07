  namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnToHousesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Houses", "UserId");
            AddForeignKey("dbo.Houses", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.Users");
            DropIndex("dbo.Houses", new[] { "UserId" });
            DropColumn("dbo.Houses", "UserId");
        }
    }
}
