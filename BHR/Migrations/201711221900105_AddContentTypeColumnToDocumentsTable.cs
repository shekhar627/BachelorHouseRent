namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContentTypeColumnToDocumentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "ContentType");
        }
    }
}
