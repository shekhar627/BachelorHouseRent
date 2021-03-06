namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThanasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Thanas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thanas");
        }
    }
}
