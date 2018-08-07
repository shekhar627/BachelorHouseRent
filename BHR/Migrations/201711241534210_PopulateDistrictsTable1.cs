namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDistrictsTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Districts (Name, DivisionId) VALUES ('Dhaka',3)");
            Sql("INSERT INTO Districts (Name, DivisionId) VALUES ('Gazipur',3)");
        }
        
        public override void Down()
        {
        }
    }
}
