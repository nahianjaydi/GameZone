namespace GameZone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Casual')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Puzzle')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Party')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Simulation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Sports')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Survival')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Strategy')");
        }
        
        public override void Down()
        {
        }
    }
}
