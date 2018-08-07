namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfirmPaymentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfirmPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        TransactionId = c.String(nullable: false, maxLength: 255),
                        AddKey = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConfirmPayments");
        }
    }
}
