namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteHouseKeyIdColumnFromManagerHousesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ManagerHouses", "HouseKeyId", "dbo.HouseKeys");
            DropIndex("dbo.ManagerHouses", new[] { "HouseKeyId" });
            DropColumn("dbo.ManagerHouses", "HouseKeyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ManagerHouses", "HouseKeyId", c => c.Int(nullable: false));
            CreateIndex("dbo.ManagerHouses", "HouseKeyId");
            AddForeignKey("dbo.ManagerHouses", "HouseKeyId", "dbo.HouseKeys", "Id", cascadeDelete: true);
        }
    }
}
