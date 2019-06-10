namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingMoviesAndGenres : DbMigration
    {
        public override void Up()
        {
            //seeding genres
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Comics')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Superhero')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Kids')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Manga')");

            // for productivity purposes we will always seed our db with 5 movies

        }
        
        public override void Down()
        {
        }
    }
}
