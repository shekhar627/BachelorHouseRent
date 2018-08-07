namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDivisionIdColumnFromHousesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Houses", new[] { "DivisionId" });
            DropColumn("dbo.Houses", "DivisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Houses", "DivisionId");
            AddForeignKey("dbo.Houses", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
    }
}
