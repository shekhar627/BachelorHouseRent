namespace BHR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDistrictsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Districts(Name) VALUES('Barguna')");
            Sql("INSERT INTO Districts(Name) VALUES('Barisal')");
            Sql("INSERT INTO Districts(Name) VALUES('Bhola')");
            Sql("INSERT INTO Districts(Name) VALUES('Jhalokati')");
            Sql("INSERT INTO Districts(Name) VALUES('Patuakhali')");
            Sql("INSERT INTO Districts(Name) VALUES('Pirojpur')");
            Sql("INSERT INTO Districts(Name) VALUES('Bandarban')");
            Sql("INSERT INTO Districts(Name) VALUES('Brahmanbaria')");
            Sql("INSERT INTO Districts(Name) VALUES('Chandpur')");
            Sql("INSERT INTO Districts(Name) VALUES('Chittagong')");
            Sql("INSERT INTO Districts(Name) VALUES('Comilla')");
            Sql("INSERT INTO Districts(Name) VALUES('Cox''s Bazar')");
            Sql("INSERT INTO Districts(Name) VALUES('Feni')");
            Sql("INSERT INTO Districts(Name) VALUES('Khagrachhari')");
            Sql("INSERT INTO Districts(Name) VALUES('Lakshmipur')");
            Sql("INSERT INTO Districts(Name) VALUES('Noakhali')");
            Sql("INSERT INTO Districts(Name) VALUES('Rangamati')");
            Sql("INSERT INTO Districts(Name) VALUES('Dhak')");
        }
        
        public override void Down()
        {
        }
    }
}
