namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDistrictIdColumnFromHousesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Houses", new[] { "DistrictId" });
            DropColumn("dbo.Houses", "DistrictId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Houses", "DistrictId");
            AddForeignKey("dbo.Houses", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
    }
}
