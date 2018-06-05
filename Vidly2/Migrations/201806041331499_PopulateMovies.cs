namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreTypeId) VALUES ('The Matrix', 1)");
            Sql("INSERT INTO Movies(Name, GenreTypeId) VALUES ('The Matrix Reloaded', 1)");
            Sql("INSERT INTO Movies (Name, GenreTypeId) VALUES ('The Matrix Revolutions', 1)");
            Sql("INSERT INTO Movies (Name, GenreTypeId) VALUES ('47 Ronin', 1)");
            Sql("INSERT INTO Movies (Name, GenreTypeId) VALUES ('Point Break', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
