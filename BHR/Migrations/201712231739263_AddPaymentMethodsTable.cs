namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentMethodsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO PaymentMethods (Name) VALUES ('bKash')");
            Sql("INSERT INTO PaymentMethods (Name) VALUES ('Dutch Bangla')");

        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentMethods");
        }
    }
}
