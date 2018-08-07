namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllDataFromDistrictsTable : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE Districts");
        }
        
        public override void Down()
        {
        }
    }
}
