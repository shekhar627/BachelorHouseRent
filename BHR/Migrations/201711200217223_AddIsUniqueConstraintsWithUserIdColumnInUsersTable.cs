namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsUniqueConstraintsWithUserIdColumnInUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "UserId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserId" });
        }
    }
}
