using System.Dynamic;

namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataInDistrictsTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Districts WHERE Name='dhak'");
            Sql("INSERT INTO Districts(Name) VALUES('Dhaka')");
        }
        
        public override void Down()
        {
        }
    }
}
