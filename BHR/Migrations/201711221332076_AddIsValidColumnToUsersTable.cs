namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsValidColumnToUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsValid", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsValid");
        }
    }
}
