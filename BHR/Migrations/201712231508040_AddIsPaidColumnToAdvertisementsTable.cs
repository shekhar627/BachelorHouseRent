namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsPaidColumnToAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "IsPaid");
        }
    }
}
