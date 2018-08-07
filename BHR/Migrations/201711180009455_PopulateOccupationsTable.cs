namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOccupationsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Occupations (Name) VALUES('Student')");
            Sql("INSERT INTO Occupations (Name) VALUES('Employee')");
            Sql("INSERT INTO Occupations (Name) VALUES('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
