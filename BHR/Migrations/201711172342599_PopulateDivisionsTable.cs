namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDivisionsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Divisions (Name) VALUES('Barisal')");
            Sql("INSERT INTO Divisions (Name) VALUES('Chittagong')");
            Sql("INSERT INTO Divisions (Name) VALUES('Dhaka')");
            Sql("INSERT INTO Divisions (Name) VALUES('Khulna')");
            Sql("INSERT INTO Divisions (Name) VALUES('Mymensingh')");
            Sql("INSERT INTO Divisions (Name) VALUES('Rajshahi')");
            Sql("INSERT INTO Divisions (Name) VALUES('Rangpur')");
            Sql("INSERT INTO Divisions (Name) VALUES('Sylhet')");
        }
        
        public override void Down()
        {
        }
    }
}
