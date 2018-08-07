namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateThanasTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Thanas (Name) VALUES ('Azampur')");
            Sql("INSERT INTO Thanas (Name) VALUES ('Badda')");
            Sql("INSERT INTO Thanas (Name) VALUES ('Bangsal')");
            Sql("INSERT INTO Thanas (Name) VALUES ('Dhanmondi')");
        }
        
        public override void Down()
        {
        }
    }
}
