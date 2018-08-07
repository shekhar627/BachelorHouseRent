namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHousesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 255),
                        DivisionId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        ThanaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.DivisionId, cascadeDelete: true)
                .ForeignKey("dbo.Thanas", t => t.ThanaId, cascadeDelete: true)
                .Index(t => t.DivisionId)
                .Index(t => t.DistrictId)
                .Index(t => t.ThanaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "ThanaId", "dbo.Thanas");
            DropForeignKey("dbo.Houses", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Houses", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Houses", new[] { "ThanaId" });
            DropIndex("dbo.Houses", new[] { "DistrictId" });
            DropIndex("dbo.Houses", new[] { "DivisionId" });
            DropTable("dbo.Houses");
        }
    }
}
