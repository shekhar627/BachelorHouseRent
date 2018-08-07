namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMapColumnFromAdvertisenentsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advertisements", "Map");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertisements", "Map", c => c.String(nullable: false));
        }
    }
}
