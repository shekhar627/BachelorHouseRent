namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyColumnToAdvertisementsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisements", "Key", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisements", "Key");
        }
    }
}
