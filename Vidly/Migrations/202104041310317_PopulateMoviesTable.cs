namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Kyle XY', '3', '2017-05-21', 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('John Wick', '1', '2020-06-11', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Young Sheldon', '5', '2016-02-25', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Boys Before Flower', '4', '2016-02-25', 3)");
        }
        
        public override void Down()
        {
        }
    }
}
