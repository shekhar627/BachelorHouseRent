namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberHousesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Key = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberHouses");
        }
    }
}
