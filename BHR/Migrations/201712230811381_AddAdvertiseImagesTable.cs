namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertiseImagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertiseImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contents = c.Binary(nullable: false),
                        ContentType = c.String(nullable: false),
                        AdvertisementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.AdvertisementId, cascadeDelete: true)
                .Index(t => t.AdvertisementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertiseImages", "AdvertisementId", "dbo.Advertisements");
            DropIndex("dbo.AdvertiseImages", new[] { "AdvertisementId" });
            DropTable("dbo.AdvertiseImages");
        }
    }
}
