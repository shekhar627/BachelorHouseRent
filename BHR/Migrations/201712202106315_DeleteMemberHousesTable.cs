namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMemberHousesTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MemberHouses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemberHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        Key = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
