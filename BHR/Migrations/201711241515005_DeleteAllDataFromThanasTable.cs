namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllDataFromThanasTable : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE Thanas");
        }
        
        public override void Down()
        {
        }
    }
}
