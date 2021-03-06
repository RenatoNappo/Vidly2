namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            //DropColumn("dbo.Movies", "GenreTypeId");
            //RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreTypeId");
            //AlterColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Movies", "GenreTypeId");
            //AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            //DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            //AlterColumn("dbo.Movies", "GenreTypeId", c => c.Int());
            //RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "Genre_Id");
            //AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
