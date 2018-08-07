namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThanaIdColumnToHousesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "ThanaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Houses", "ThanaId");
            AddForeignKey("dbo.Houses", "ThanaId", "dbo.Thanas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "ThanaId", "dbo.Thanas");
            DropIndex("dbo.Houses", new[] { "ThanaId" });
            DropColumn("dbo.Houses", "ThanaId");
        }
    }
}
