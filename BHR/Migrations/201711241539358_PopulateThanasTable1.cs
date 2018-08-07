namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateThanasTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Thanas (Name, DistrictId) VALUES ('Badda',1)");
            Sql("INSERT INTO Thanas (Name, DistrictId) VALUES ('Dhanmondi',1)");
        }
        
        public override void Down()
        {
        }
    }
}
