namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        DivisionId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        PublishDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Divisions", t => t.DivisionId)
                .ForeignKey("dbo.Thanas", t => t.ThanaId)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictId)
                .Index(t => t.ThanaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisements", "ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.Advertisements", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Advertisements", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Advertisements", new[] { "ThanaId" });
            DropIndex("dbo.Advertisements", new[] { "DistrictId" });
            DropIndex("dbo.Advertisements", new[] { "DivisionId" });
            DropTable("dbo.Advertisements");
        }
    }
}
