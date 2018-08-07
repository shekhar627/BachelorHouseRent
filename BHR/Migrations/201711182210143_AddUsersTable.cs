namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MobileNumber = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        UserId = c.String(nullable: false, maxLength: 50),
                        IsAManager = c.Boolean(),
                        IsAHouseOwner = c.Boolean(),
                        OccupationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Occupations", t => t.OccupationId, cascadeDelete: true)
                .Index(t => t.OccupationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OccupationId", "dbo.Occupations");
            DropIndex("dbo.Users", new[] { "OccupationId" });
            DropTable("dbo.Users");
        }
    }
}
