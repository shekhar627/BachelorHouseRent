namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentContents = c.Binary(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropTable("dbo.Documents");
        }
    }
}
