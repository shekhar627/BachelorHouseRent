namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHouseKeysTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.HouseId)
                .Index(t => t.Key, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseKeys", "HouseId", "dbo.Houses");
            DropIndex("dbo.HouseKeys", new[] { "Key" });
            DropIndex("dbo.HouseKeys", new[] { "HouseId" });
            DropTable("dbo.HouseKeys");
        }
    }
}
