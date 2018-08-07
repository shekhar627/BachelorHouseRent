namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCheckedByAdminColumnToConfirmPaymentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConfirmPayments", "IsCheckedByAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConfirmPayments", "IsCheckedByAdmin");
        }
    }
}
