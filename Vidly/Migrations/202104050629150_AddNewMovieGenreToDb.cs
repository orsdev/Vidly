namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMovieGenreToDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Revival', '2', '2011-01-11', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
