namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapColumnToAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Map", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Map");
        }
    }
}
