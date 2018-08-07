namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteThanaIdColumnFromHousesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "ThanaId", "dbo.Thanas");
            DropIndex("dbo.Houses", new[] { "ThanaId" });
            DropColumn("dbo.Houses", "ThanaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "ThanaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Houses", "ThanaId");
            AddForeignKey("dbo.Houses", "ThanaId", "dbo.Thanas", "Id", cascadeDelete: true);
        }
    }
}
