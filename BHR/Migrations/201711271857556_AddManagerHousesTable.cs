namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManagerHousesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManagerHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        HouseKeyId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HouseKeys", t => t.HouseKeyId, cascadeDelete: true)
                .Index(t => t.HouseKeyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagerHouses", "HouseKeyId", "dbo.HouseKeys");
            DropIndex("dbo.ManagerHouses", new[] { "HouseKeyId" });
            DropTable("dbo.ManagerHouses");
        }
    }
}
