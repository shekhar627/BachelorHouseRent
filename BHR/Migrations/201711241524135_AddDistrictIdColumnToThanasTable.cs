namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistrictIdColumnToThanasTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thanas", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Thanas", "DistrictId");
            AddForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Thanas", new[] { "DistrictId" });
            DropColumn("dbo.Thanas", "DistrictId");
        }
    }
}
