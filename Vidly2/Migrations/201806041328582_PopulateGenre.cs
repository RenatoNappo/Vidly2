namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Science Fiction')");
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Crime Thriller')");
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Horror')");
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Historical')");
            Sql("INSERT INTO Genres (GenreDescription) VALUES ('Period Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
