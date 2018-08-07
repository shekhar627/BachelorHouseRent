namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDivisionIdColumnToDistrictsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Districts", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "DivisionId");
            AddForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Districts", new[] { "DivisionId" });
            DropColumn("dbo.Districts", "DivisionId");
        }
    }
}
