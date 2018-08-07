namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceColumnToAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Price", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Price");
        }
    }
}
